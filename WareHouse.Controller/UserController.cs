using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WareHouse.Service.Interfaces;
using WareHouse.Core.Models;
using WareHouse.Core.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WareHouse.Controller
{
    [Authorize]
    [ApiController]
    [Route("api")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        //Non-authentication
        [AllowAnonymous]
        [HttpPost("auth/login")]
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
        [HttpPost("adduser")]
        public IActionResult AddUser([FromBody] List<UserNoId> users)
        {
            var arr = _userService.AddUser(users);
            if (arr == null) return BadRequest(new { message =  Constant.CREATE_USER_FAILED });
            return Ok(new {message = Constant.CREATE_USER_SUCCESSFULLY, data = arr });
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPut("updateuser")]
        public IActionResult UpdateUser([FromBody] List<UserUpdate> newUsers)
        {
            var arr = _userService.UpdateUser(newUsers);
            if (arr == null) return BadRequest(new { message = Constant.UPDATE_USER_FAILED });
            return Ok(new { message = Constant.UPDATE_USER_SUCCESSFULLY, data = arr });
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPost("deleteuser")]
        public IActionResult DeleteUser([FromBody] List<int> listUserId)
        {
            var kt = _userService.DeleteUser(listUserId);
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