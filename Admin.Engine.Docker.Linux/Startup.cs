using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using Admin.Service;
using Admin.Service.Impls;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using FluentValidation.AspNetCore;
using Login.Helper.Helper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QSI.Automapper.Extension;
using QSI.MassTransit.Boot.Starter.AspNetCore;
using QSI.MassTransit.Boot.Starter.Configurations;
using QSI.MassTransit.Boot.Starter.Extensions;
using QSI.ORM.Config;
using QSI.ORM.NHibernate.Extension;
using QSI.Web.Middleware;
using Swashbuckle.AspNetCore.Swagger;


namespace Admin.Engine.Docker.Linux
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddYamlFile("configuration.yml", optional: false, reloadOnChange: true)
                .AddYamlFile($"configuration.{env.EnvironmentName}.yml", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            services.AddSingleton(Configuration);
            services.AddTransient<LogActionFilter>();
            services
                .AddMvc(options =>
                {
                    options.Filters.AddService<LogActionFilter>();
                })
                .AddControllersAsServices();

            services.AddCors();

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, LoginHelper>("BasicAuthentication", null);
            services.AddScoped<ILoginService, LoginService>();

            #region ORM
            var setting = new DatabaseConfiguration();
            Configuration.Bind("orm", setting);
            services.AddConnection(setting);
            #endregion

            #region Security & JWT
            services.AddMvc(options =>
            {
                options.CacheProfiles.Add("Default",
                    new CacheProfile()
                    {
                        NoStore = true,
                        Duration = 0
                    });

            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            //builder.AddDatabaseAuthentication();
            #endregion

            #region Automapper
            services.AddAutoMapper(mapperConfig => {
                mapperConfig.AddProfiles(new string[] {
                    "Admin.Service"
                });
                mapperConfig.IgnoreUnmapped();
            });
            #endregion

            #region Compress HTTP Connection
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "image/svg+xml" });
            });
            #endregion

            #region masstransit configuration
            MassTransitBootConfiguration masstransitBootConfiguration = new MassTransitBootConfiguration();
            Configuration.Bind("masstransit", masstransitBootConfiguration);
            builder.UseMassTransit(masstransitBootConfiguration);
            services.AddSingleton<Microsoft.Extensions.Hosting.IHostedService, BusService>();
            #endregion

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc($"{Configuration.GetSection("swagger:generator:doc").GetValue<string>("name")}", new Info { Title = $"{Configuration.GetSection("swagger:generator:doc:info").GetValue<string>("title")}", Version = $"{Configuration.GetSection("swagger:generator:doc:info").GetValue<string>("version")}" });
                if (Configuration.GetSection("swagger:generator").GetValue<bool>("describeAllEnumsAsStrings"))
                    c.DescribeAllEnumsAsStrings();
            });
            #endregion

            #region Custom Integration
            //var externalEndpoint = new ExternalEndpoint();
            //Configuration.Bind("externalEndpoint", externalEndpoint);

            //var generalConfig = new GeneralConfig();
            //Configuration.Bind("generalConfig", generalConfig);

            //services.AddExternalEndpoint(externalEndpoint);
            //services.AddProjectConsumerExtension(generalConfig);

            //builder.RegisterType<ProjectAPIService>().As<IProjectAPIService>();

            //var groupInsuranceApplicationUri = new Uri($"{masstransitBootConfiguration.MassTransitConfiguration.BaseUrl}/project-service");
            //builder.AddProjectRequest(groupInsuranceApplicationUri);

            var inventoryUri = new Uri($"{masstransitBootConfiguration.MassTransitConfiguration.BaseUrl}/QSI.DeveloperTest.Inventory-service");
            #endregion

            #region Transactional Assemblies
            Assembly[] assemblies = new Assembly[]
            {
                Assembly.Load("Admin.Repository.NHibernate"),
                Assembly.Load("Admin.Service")
            };

            builder.RegisterTransactionalAssemblies(assemblies, e =>
            {
                var context = e.Resolve<IHttpContextAccessor>();
                return context.HttpContext.User.Identity.Name;
            });

            builder.RegisterCriteriaCondition();
            builder.RegisterGeneralHelperDao();
            #endregion

            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();

            builder.Populate(services);

            ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, Microsoft.Extensions.Logging.ILoggerFactory loggerFactory, IApplicationLifetime appLifetime)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddLog4Net(Configuration.GetValue<string>("Log4NetConfigFile:Name"));

            if (env.IsDevelopment())
            {
                ResponseActionFactory factory = new ResponseActionFactory();
                factory.AddCase(async (e, c) =>
                {
                    var ce = e as QSI.FluentValidation.ValidationException;
                    if (ce != null)
                    {
                        c.Response.ContentType = "application/json";
                        c.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        var ex = new QSI.Web.Middleware.JsonException()
                        {
                            ErrorCode = ce.ErrorCode,
                            Message = ce.Message,
                            MessageKey = ce.MessageKey,
                            Exception = e.GetType().FullName,
                            Data = new Dictionary<string, object>
                            {
                                { "Failures", ce.Failures }
                            }
                        };

                        await c.Response.WriteAsync(JsonConvert.SerializeObject(ex));
                        return true;
                    }
                    return false;
                });
                app.UseMiddleware<MiddlewareExceptionShaper>(factory);
            }
            else
                app.UseMiddleware<MiddlewareExceptionShaper>();

            #region Swagger
            app.UseSwagger(c =>
            {
                c.RouteTemplate = $"{Configuration.GetSection("swagger:route").GetValue<string>("template")}";
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) => swaggerDoc.Host = httpReq.Host.Value);
            });
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = $"{Configuration.GetSection("swagger:ui").GetValue<string>("prefix")}";
                c.DocumentTitle = $"{Configuration.GetSection("swagger:ui").GetValue<string>("documentTitle")}";
                c.SwaggerEndpoint($"{Configuration.GetSection("swagger:ui:endpoint").GetValue<string>("url")}", $"{Configuration.GetSection("swagger:ui:endpoint").GetValue<string>("name")}");
            });
            #endregion

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseResponseCompression();

            #region Security
            //app.UseSecureHeaders();
            //app.UseAuthentication();
            app.UseHttpsRedirection();
            #endregion

            app.UseMvc();
            appLifetime.ApplicationStopped.Register(() => this.ApplicationContainer.Dispose());
        }
    }
}
