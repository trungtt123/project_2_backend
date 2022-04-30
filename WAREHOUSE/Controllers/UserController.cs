using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WAREHOUSE.Services;
using WAREHOUSE.Models;
using WAREHOUSE.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
namespace WAREHOUSE.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IHelpers _helpers;
        public UserController(IUserService userService, IHelpers helpers)
        {
            _userService = userService;
            _helpers = helpers;
            
        }
        // Non-authentication
        [AllowAnonymous]
        [HttpPost("auth/login")]
        public IActionResult Authenticate([FromBody] UserLogin userData)
        {
            var user = _userService.Authenticate(userData);
            if (user == null)
                return BadRequest(new { message = Constant.USERNAME_OR_PASSWORD_IS_INCORRECT });

            return Ok(user);
        }
        //Authentication + Permission (admin, manager, stocker)
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, 
            Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpGet("getuser")]
        public IActionResult GetUser(string userName)
        {
            Console.WriteLine(userName + "123");
            var user = _userService.GetUserFromUserName(userName);
            string status = _helpers.GetResponseStatus(user.Message);

            if (status == "200") return Ok(user);
            if (status == "400") return BadRequest(user);


            return Ok(user);
        }
        //Authentication + Permission (admin)
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Constant.Administrator)]
        [HttpPost("createuser")]
        public IActionResult CreateUser([FromBody] User userData)
        {
            var user = _userService.CreateUser(userData);
            string status = _helpers.GetResponseStatus(user.Message);

            if (status == "200") return Ok(user);
            if (status == "400") return BadRequest(user);

            return Ok(user);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        [HttpDelete("deleteuser")]
        public IActionResult DeleteUser(string userName)
        {
            var user = _userService.DeleteUser(userName);
            string status = _helpers.GetResponseStatus(user.Message);

            if (status == "200") return Ok(user);
            if (status == "400") return BadRequest(user);

            return Ok(user);
        }
    }
}