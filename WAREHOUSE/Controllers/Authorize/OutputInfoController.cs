using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WareHouse.Service.Interfaces;
using WareHouse.Core.Models;
using WareHouse.Core.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using WareHouse.Controllers;

namespace WareHouse
{
    [VerifyRoleFilter]
    [Authorize]
    [ApiController]
    [Route(Constant.API_BASE)]
    
    public class OutputInfoController : ControllerBase
    {
        private readonly IOutputInfoService _outputInfoService;
        public OutputInfoController(IOutputInfoService outputInfoService)
        {
            _outputInfoService = outputInfoService;

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpGet("list-output-info")]
        public IActionResult GetListOutputInfo()
        {
            var listOutputInfo = _outputInfoService.GetListOutputInfo();
            var response = new ResponseDto();
            if (listOutputInfo == null)
            {

                response.Message = Constant.GET_LIST_OUTPUT_INFO_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.GET_LIST_OUTPUT_INFO_SUCCESSFULLY;
            response.Data = listOutputInfo;
            return Ok(Helpers.SerializeObject(response));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpGet("output-info")]
        public IActionResult GetOutputInfo(int outputInfoId)
        {
            var outputInfo = _outputInfoService.GetOutputInfo(outputInfoId);
            var response = new ResponseDto();
            if (outputInfo == null)
            {
                
                response.Message = Constant.GET_OUTPUT_INFO_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.GET_OUTPUT_INFO_SUCCESSFULLY;
            response.Data = outputInfo;
            return Ok(Helpers.SerializeObject(response));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPost("output-info")]
        public IActionResult CreateOutputInfo([FromBody] OutputInfoNoIdDto outputInfo)
        { 

            var kt = _outputInfoService.CreateOutputInfo(outputInfo);
            var response = new ResponseDto();
            
            if (!kt)
            {
                response.Message = Constant.CREATE_OUTPUT_INFO_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.CREATE_OUTPUT_INFO_SUCCESSFULLY;
            return Ok(Helpers.SerializeObject(response));
            
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPost("output-info/products")]
        public IActionResult OutputInfoAddProduct([FromBody] OutputProductNoIdDto outputProductDto, int outputInfoId)
        {
            var kt = _outputInfoService.OutputInfoAddProduct(outputProductDto, outputInfoId);

            var response = new ResponseDto();

            if (!kt)
            {
                response.Message = Constant.OUTPUT_INFO_ADD_PRODUCT_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.OUTPUT_INFO_ADD_PRODUCT_SUCCESSFULLY;
            return Ok(Helpers.SerializeObject(response));

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPut("output-info/products")]
        public IActionResult OutputInfoUpdateProduct([FromBody] OutputProductNoIdDto newOutputProductDto, int id)
        {
            var kt = _outputInfoService.OutputInfoUpdateProduct(newOutputProductDto, id);

            var response = new ResponseDto();

            if (!kt)
            {
                response.Message = Constant.OUTPUT_INFO_UPDATE_PRODUCT_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.OUTPUT_INFO_UPDATE_PRODUCT_SUCCESSFULLY;
            return Ok(Helpers.SerializeObject(response));

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpDelete("output-info/products")]
        public IActionResult OutputInfoRemoveProduct(int id)
        {
            var kt = _outputInfoService.OutputInfoRemoveProduct(id);
            var response = new ResponseDto();

            if (!kt)
            {
                response.Message = Constant.OUTPUT_INFO_REMOVE_PRODUCT_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.OUTPUT_INFO_REMOVE_PRODUCT_SUCCESSFULLY;
            return Ok(Helpers.SerializeObject(response));

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPut("output-info")]
        public IActionResult UpdateOutputInfo(int outputInfoId, [FromBody] OutputInfoNoIdDto newOutputInfo)
        {
            var kt = _outputInfoService.UpdateOutputInfo(outputInfoId, newOutputInfo);
            var response = new ResponseDto();

            if (!kt)
            {
                response.Message = Constant.UPDATE_OUTPUT_INFO_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.UPDATE_OUTPUT_INFO_SUCCESSFULLY;
            return Ok(Helpers.SerializeObject(response));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpDelete("output-info")]
        public IActionResult DeleteOutputInfo(int outputInfoId)
        {
            var kt = _outputInfoService.DeleteOutputInfo(outputInfoId);
            var response = new ResponseDto();

            if (kt) {
                
                response.Message = Constant.DELETE_OUTPUT_INFO_SUCCESSFULLY;
                return Ok(Helpers.SerializeObject(response));
            }
            response.Message = Constant.DELETE_OUTPUT_INFO_FAILED;
            return BadRequest(Helpers.SerializeObject(response));                                                                              
        }
    }
}