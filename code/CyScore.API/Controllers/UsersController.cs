using CyScore.API.Interfaces;
using CyScore.Data.Interfaces;
using CyScore.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CyScore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpPost("signup")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUpAsync([FromBody]UserView user)
        {
            await userService.Signup(user);
            return new OkResult();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]UserView user)
        {
            bool loginSuccess = userService.AuthenticateUser(user);
            if (!loginSuccess)
            {
                return BadRequest();
            }
            string token = userService.GenerateJsonWebToken(user);
            return Ok(token);
        }

        [HttpGet("verify")]
        [Authorize]
        public IEnumerable<string> Verify()
        {
            return new string[] { "value1", "value2" };
        }

    }
}
