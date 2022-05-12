using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WareHouse.Service.Interfaces;
using WareHouse.Core.Models;
using WareHouse.Core.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WareHouse
{
    [Authorize]
    [ApiController]
    [Route("api/v1")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
           
        }
        //Non-authentication
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] UserLogin userData)
        {
            var user = _userService.Authenticate(userData);
            if (user == null)
                return BadRequest(new { message = Constant.USERNAME_OR_PASSWORD_IS_INCORRECT });



            return Ok(new { message = Constant.AUTHENTICATION_SUCCESSFULLY, data = user});

        }
        
        [HttpGet("getlistpermissions")]
        [AllowAnonymous]
        public IActionResult GetListPermissions()
        {

            var listPermissions = _userService.GetListPermissions();
            return Ok(listPermissions);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpGet("user")]
        public IActionResult GetUser(int userId)
        {
            var user = _userService.GetUser(userId);
            if (user == null) return BadRequest(new { message = Constant.GET_USER_FAILED });
            return Ok(new { message = Constant.GET_USER_SUCCESSFULLY, data = user });
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPost("user")]
        public IActionResult CreateUser([FromBody] UserNoId user)
        {
            var userResponse = _userService.CreateUser(user);
           
            if (userResponse == null) return BadRequest(new { message =  Constant.CREATE_USER_FAILED });

            return Ok(new { message = Constant.CREATE_USER_SUCCESSFULLY, data = userResponse });
            
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPut("user")]
        public IActionResult UpdateUser([FromBody] UserUpdate newUserData)
        {
            var kt = _userService.UpdateUser(newUserData);
            if (!kt) return BadRequest(new { message = Constant.UPDATE_USER_FAILED });
            return Ok(new { message = Constant.UPDATE_USER_SUCCESSFULLY});
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpDelete("user")]
        public IActionResult DeleteUser(int userId)
        {
            var kt = _userService.DeleteUser(userId);
            if (kt) return Ok(new { message = Constant.DELETE_USER_SUCCESSFULLY });
            return BadRequest(new { message = Constant.DELETE_USER_FAILED });                                                                              
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpGet("getallusers")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            if (users == null) return BadRequest(new { message =  Constant.GET_ALL_USERS_FAILED});
            return Ok(new { message = Constant.GET_USER_SUCCESSFULLY, data = users });
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPut("changepassword")]
        public IActionResult ChangePassWord([FromBody] UserChangePassWord userData)
        {
            var kt = _userService.ChangePassWord(userData);
            if (!kt) return BadRequest(new { message = Constant.CHANGE_PASSWORD_FAILED });
            return Ok(new { message = Constant.CHANGE_PASSWORD_SUCCESSFULLY });
        }
    }
}