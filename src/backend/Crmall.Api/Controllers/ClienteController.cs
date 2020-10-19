using Crmall.Domain.DTOs;
using Crmall.Domain.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Crmall.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IServiceCliente _serviceCliente;

        public ClienteController(IServiceCliente serviceCliente)
        {
            _serviceCliente = serviceCliente;
        }

        [HttpPost]
        public IActionResult Salvar(ClienteDTO cliente)
        {
            var response = _serviceCliente.Salvar(cliente);

            if (!response.IsSucceed)
            {
                return BadRequest(response.Messages);
            }

            return Ok(response.Messages);
        }

        [HttpPut]
        public IActionResult Editar(ClienteDTO cliente)
        {
            var response = _serviceCliente.Editar(cliente);

            if (!response.IsSucceed)
            {
                return BadRequest(response.Messages);
            }

            return Ok(response.Messages);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var response = _serviceCliente.Listar();

            if (!response.IsSucceed)
            {
                return BadRequest(response.Messages);
            }

            return Ok(response.Data);
        }

        [HttpDelete("{Id}")]
        public IActionResult Remover(Guid id)
        {
            var response = _serviceCliente.Remover(id);

            if (!response.IsSucceed)
            {
                return BadRequest(response.Messages);
            }

            return Ok(response.Messages);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(Guid id)
        {
            var response = _serviceCliente.GetById(id);

            if (!response.IsSucceed)
            {
                return BadRequest(response.Messages);
            }

            return Ok(response.Data);
        }
    }
}
