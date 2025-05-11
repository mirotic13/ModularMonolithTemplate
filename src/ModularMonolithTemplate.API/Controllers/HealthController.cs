using Microsoft.AspNetCore.Mvc;

namespace ModularMonolithTemplate.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {

        [HttpGet]
        [HttpHead]
        public IActionResult Health()
        {
            return Ok("Healthy");
        }
    }
}
