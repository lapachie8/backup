using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Admin.Engine.Docker.Linux
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingCtx, config) =>
                {
                    config.AddJsonFile("appsettings.config", optional: true, reloadOnChange: true);
                    config.AddYamlFile("configuration.yml", optional: false, reloadOnChange: true);
                    config.AddYamlFile($"configuration.{hostingCtx.HostingEnvironment.EnvironmentName}.yml", optional: true, reloadOnChange: true);
                })
                .ConfigureLogging(logger =>
                {
                    logger.AddLog4Net();
                })
                .UseStartup<Startup>();
    }
}
