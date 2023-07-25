using cliente.Core.Application.Interfaces;
using cliente.Core.Domain.Client.DTO;
using cliente.Core.Domain.Client.Entities;
using Microsoft.AspNetCore.Mvc;

namespace cliente.UserEntry.Http
{
    [ApiController]
    public class ClientesController : Controller
    {
        private readonly IClienteApplication _clientesApplication;
        public ClientesController(IClienteApplication clientesApplication)
        {
            _clientesApplication = clientesApplication;
        }

        [Route("api/clientes")]
        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            try
            {
                var clientes = await _clientesApplication.FindClients();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("api/clientes")]
        [HttpPost]
        public async Task<IActionResult> CreateCompany(ClienteSaveDTO cliente)
        {
            try
            {
                var createdCompany = await _clientesApplication.Save(cliente);
                return Ok(createdCompany);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [Route("api/getNumber")]
        [HttpGet]
        public async Task<IActionResult> getNumber(int numb)
        {
            return Ok(numb + 1);
        }
    }
}
