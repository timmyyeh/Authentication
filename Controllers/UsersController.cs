using authentication.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace authentication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        // dependency injection
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            var result = _userService.CreateUser(user);
            return new JsonResult(new {user = result}) {StatusCode = StatusCodes.Status200OK};
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest request)
        {
            var response = _userService.Authenticate(request);
            if (response == null) return BadRequest(new {message = "Username or password is incorrect"});
            return Ok(response);
        }
    }
}