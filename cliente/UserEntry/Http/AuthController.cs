using cliente.Core.Application.Auth.Interface;
using cliente.Core.Application.Implementation;
using cliente.Core.Application.Interfaces;
using cliente.Core.Domain.Auth.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cliente.UserEntry.Http
{
    public class AuthController : Controller
    {
        private readonly IAuthApplication _authApplication;
        public AuthController(IAuthApplication authApplication)
        {
            _authApplication = authApplication;
        }

        /// <summary>
        /// Autenticação
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] AutenticateUserDTO user)
        {
            try
            {
                var clientes = await _authApplication.Login(user);
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Registration
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Registration")]
        [AllowAnonymous]
        public async Task<IActionResult> Registration([FromBody] AutenticateUserDTO user)
        {
            try
            {
                var clientes = await _authApplication.Login(user);
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => $"Autenticado - {User.Identity.Name}";

        [HttpGet]
        [Route("allRoles")]
        [Authorize]
        public string Employee() => "Funcionário";

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "manager")]
        public string Manager() => "Gerente";
    }
}
