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
    
    public class InputInfoController : ControllerBase
    {
        private readonly IInputInfoService _inputInfoService;
        public InputInfoController(IInputInfoService inputInfoService)
        {
            _inputInfoService = inputInfoService;

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpGet("list-input-info")]
        public IActionResult GetListInputInfo()
        {
            var listInputInfo = _inputInfoService.GetListInputInfo();
            var response = new ResponseDto();
            if (listInputInfo == null)
            {

                response.Message = Constant.GET_LIST_INPUT_INFO_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.GET_LIST_INPUT_INFO_SUCCESSFULLY;
            response.Data = listInputInfo;
            return Ok(Helpers.SerializeObject(response));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpGet("input-info")]
        public IActionResult GetInputInfo(int inputInfoId)
        {
            var inputInfo = _inputInfoService.GetInputInfo(inputInfoId);
            var response = new ResponseDto();
            if (inputInfo == null)
            {
                
                response.Message = Constant.GET_INPUT_INFO_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.GET_INPUT_INFO_SUCCESSFULLY;
            response.Data = inputInfo;
            return Ok(Helpers.SerializeObject(response));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPost("input-info")]
        public IActionResult CreateInputInfo([FromBody] InputInfoNoIdDto inputInfo)
        { 

            var kt = _inputInfoService.CreateInputInfo(inputInfo);
            var response = new ResponseDto();
            
            if (!kt)
            {
                response.Message = Constant.CREATE_INPUT_INFO_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.CREATE_INPUT_INFO_SUCCESSFULLY;
            return Ok(Helpers.SerializeObject(response));
            
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPost("input-info/product-batches")]
        public IActionResult InputInfoAddProductBatch(int inputInfoId, int productBatchId)
        {
            var kt = _inputInfoService.InputInfoAddProductBatch(productBatchId, inputInfoId);

            var response = new ResponseDto();

            if (!kt)
            {
                response.Message = Constant.INPUT_INFO_ADD_PRODUCT_BATCH_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.INPUT_INFO_ADD_PRODUCT_BATCH_SUCCESSFULLY;
            return Ok(Helpers.SerializeObject(response));

        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpDelete("input-info/product-batches")]
        public IActionResult InputInfoRemoveProductBatch(int productBatchId)
        {
            var kt = _inputInfoService.InputInfoRemoveProductBatch(productBatchId);
            var response = new ResponseDto();

            if (!kt)
            {
                response.Message = Constant.INPUT_INFO_REMOVE_PRODUCT_BATCH_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.INPUT_INFO_REMOVE_PRODUCT_BATCH_SUCCESSFULLY;
            return Ok(Helpers.SerializeObject(response));

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPut("input-info")]
        public IActionResult UpdateInputInfo(int inputInfoId, [FromBody] InputInfoNoIdDto newInputInfo)
        {
            var kt = _inputInfoService.UpdateInputInfo(inputInfoId, newInputInfo);
            var response = new ResponseDto();

            if (!kt)
            {
                response.Message = Constant.UPDATE_INPUT_INFO_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.UPDATE_INPUT_INFO_SUCCESSFULLY;
            return Ok(Helpers.SerializeObject(response));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpDelete("input-info")]
        public IActionResult DeleteInputInfo(int inputInfoId)
        {
            var kt = _inputInfoService.DeleteInputInfo(inputInfoId);
            var response = new ResponseDto();

            if (kt) {
                
                response.Message = Constant.DELETE_INPUT_INFO_SUCCESSFULLY;
                return Ok(Helpers.SerializeObject(response));
            }
            response.Message = Constant.DELETE_INPUT_INFO_FAILED;
            return BadRequest(Helpers.SerializeObject(response));                                                                              
        }
    }
}