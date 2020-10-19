using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Crmall.Api.Controllers
{
    [Route("/")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

            return Ok(string.Format("Crmall CRUD API v.{0}", fvi.FileVersion));
        }
    }
}
