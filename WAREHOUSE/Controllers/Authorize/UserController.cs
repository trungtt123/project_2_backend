using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WareHouse.Service.Interfaces;
using WareHouse.Core.Models;
using WareHouse.Core.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WareHouse.Controllers;

namespace WareHouse
{
    [VerifyRoleFilter]
    [Authorize]
    [ApiController]
    [Route(Constant.API_BASE)]
    
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpGet("verifytoken")]
        public IActionResult VerifyToken()
        {
            var response = new ResponseDto();
            response.message = Constant.INVALID_TOKEN;
            try
            {
                var jwt = Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
                var kt = _userService.VerifyToken(jwt);
                if (!kt) return new UnauthorizedResult();
                response.message = Constant.VALID_TOKEN;
                return Ok(Helpers.SerializeObject(response));
            }
            catch (Exception ex)
            {
                return new UnauthorizedResult();
            }
        }

        [HttpGet("getlistpermissions")]
        [AllowAnonymous]
        public IActionResult GetListPermissions()
        {
            var response = new ResponseDto();
            var listPermissions = _userService.GetListPermissions();
            if (listPermissions != null)
            {
                response.message = Constant.GET_LIST_PERMISSIONS_SUCCESSFULLY;
                response.data = listPermissions;
                return Ok(Helpers.SerializeObject(response));
            }
            else
            {
                response.message = Constant.GET_LIST_PERMISSIONS_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpGet("user")]
        public IActionResult GetUser(int userId)
        {
            var user = _userService.GetUser(userId);
            var response = new ResponseDto();
            if (user == null)
            {
                
                response.message = Constant.GET_USER_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.message = Constant.GET_USER_SUCCESSFULLY;
            response.data = user;
            return Ok(Helpers.SerializeObject(response));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPost("user")]
        public IActionResult CreateUser([FromBody] UserNoIdDto user)
        {
            var userResponse = _userService.CreateUser(user);
            var response = new ResponseDto();

            if (userResponse == null)
            {
                response.message = Constant.CREATE_USER_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.message = Constant.CREATE_USER_SUCCESSFULLY;
            response.data = userResponse;
            return Ok(Helpers.SerializeObject(response));
            
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPut("user")]
        public IActionResult UpdateUser([FromBody] UserUpdateDto newUserData)
        {
            var kt = _userService.UpdateUser(newUserData);
            var response = new ResponseDto();

            if (!kt)
            {
                response.message = Constant.UPDATE_USER_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.message = Constant.UPDATE_USER_SUCCESSFULLY;
            return Ok(Helpers.SerializeObject(response));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpDelete("user")]
        public IActionResult DeleteUser(int userId)
        {
            var kt = _userService.DeleteUser(userId);
            var response = new ResponseDto();

            if (kt) {
                
                response.message = Constant.DELETE_USER_SUCCESSFULLY;
                return Ok(Helpers.SerializeObject(response));
            }
            response.message = Constant.DELETE_USER_FAILED;
            return BadRequest(Helpers.SerializeObject(response));                                                                              
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpGet("getallusers")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            var response = new ResponseDto();

            if (users == null)
            {
                response.message = Constant.GET_ALL_USERS_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.message = Constant.GET_ALL_USERS_SUCCESSFULLY;
            response.data = users;
            return Ok(Helpers.SerializeObject(response));
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPut("changepassword")]
        
        public IActionResult ChangePassWord([FromBody] UserChangePassWordDto userData)
        {
            var kt = false;
            var jwt = Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
            var userName = Helpers.DecodeJwt(jwt, "username");

            if (userName == userData.UserName) kt = _userService.ChangePassWord(userData);
            var response = new ResponseDto();
            if (!kt)
            {
                response.message = Constant.CHANGE_PASSWORD_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.message = Constant.CHANGE_PASSWORD_SUCCESSFULLY;
            return Ok(Helpers.SerializeObject(response));
        }
    }
}