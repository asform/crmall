using Crmall.Domain.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;

namespace Crmall.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IServiceCEP _serviceCEP;

        public CepController(IServiceCEP serviceCEP)
        {
            _serviceCEP = serviceCEP;
        }

        [HttpGet("{cep}")]
        public IActionResult ConsultarCEP(string cep)
        {
            var response = _serviceCEP.ConsultarCep(cep);

            if (!response.IsSucceed)
            {
                return BadRequest(response.Messages);
            }

            return Ok(response.Data);
        }
    }
}
