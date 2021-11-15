using Microsoft.AspNetCore.Mvc;

namespace authentication.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class HelloWorldController : ControllerBase
    {
        [Authorize]
        [HttpPost("ping")]
        public IActionResult HelloWorld()
        {
            return Ok(new {message = "alive"});
        }
    }
}