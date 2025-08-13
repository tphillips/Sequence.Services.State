using Microsoft.AspNetCore.Mvc;

namespace Sequence.Services.State.Controllers
{
	[ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return $"Sequence.Services.State v2.0.0";
        }
    }
}
