using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WareHouse.Service.Interfaces;
using WareHouse.Core.Models;
using WareHouse.Core.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WareHouse.Controllers;

namespace WareHouse
{
    [Authorize]
    [ApiController]
    [Route(Constant.API_BASE)]
    public class CommonController : ControllerBase
    {
        private readonly IUserService _userService;
        public CommonController(IUserService userService)
        {
            _userService = userService;
        }
        //Non-authentication
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] UserLoginDto userData)
        {
            var user = _userService.Authenticate(userData);
            
            var response = new ResponseDto();

            if (user == null)
            {
                response.message = Constant.USERNAME_OR_PASSWORD_IS_INCORRECT;
                
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.message = Constant.AUTHENTICATION_SUCCESSFULLY;
            response.data = user;
            return Ok(Helpers.SerializeObject(response));

        }
        
    }
}