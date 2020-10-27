using Admin.Common.Commands;
using Admin.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Api.AspNetCore.Controller
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [AllowAnonymous]
        [HttpPost("{authenticate}")]
        public async Task<IActionResult> Authenticate([FromBody] LoginCommand command)
        {
            var login = await _loginService.Authenticate(command.userName, command.password);
            if (login == null)
                return BadRequest(new { message = "username atau password salah" });

            return Ok(login);
        }
        [HttpGet]
        public async Task<IActionResult> GetALl()
        {
            var login = await _loginService.GetAll();

            return Ok(login);
        }
    }
}
