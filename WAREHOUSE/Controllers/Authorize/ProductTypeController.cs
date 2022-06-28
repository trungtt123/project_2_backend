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
    
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _iproductTypeService;
        public ProductTypeController(IProductTypeService iproductTypeService)
        {
            _iproductTypeService = iproductTypeService;

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpGet("list-product-types")]
        public IActionResult GetListProductTypes()
        {
            var productTypes = _iproductTypeService.GetListProductTypes();
            var response = new ResponseDto();
            if (productTypes == null)
            {

                response.Message = Constant.GET_LIST_PRODUCT_TYPES_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.GET_LIST_PRODUCT_TYPES_SUCCESSFULLY;
            response.Data = productTypes;
            return Ok(Helpers.SerializeObject(response));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpGet("product-type")]
        public IActionResult GetProductType(int productTypeId)
        {
            var productType = _iproductTypeService.GetProductType(productTypeId);
            var response = new ResponseDto();
            if (productType == null)
            {
                
                response.Message = Constant.GET_PRODUCT_TYPE_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.GET_PRODUCT_TYPE_SUCCESSFULLY;
            response.Data = productType;
            return Ok(Helpers.SerializeObject(response));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpPost("product-type")]
        public IActionResult CreateProductType([FromBody] string productTypeName)
        {
            var productType = _iproductTypeService.CreateProductType(productTypeName);
            var response = new ResponseDto();

            if (!productType)
            {
                response.Message = Constant.CREATE_PRODUCT_TYPE_FAILED;
                return BadRequest(response);
            }
            response.Message = Constant.CREATE_PRODUCT_TYPE_SUCCESSFULLY;
            return Ok(Helpers.SerializeObject(Helpers.SerializeObject(response)));
            
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpPut("product-type")]
        public IActionResult UpdateProductType(int productTypeId, [FromBody] string newProductTypeName)
        {
            var kt = _iproductTypeService.UpdateProductType(productTypeId, newProductTypeName);
            var response = new ResponseDto();

            if (!kt)
            {
                response.Message = Constant.UPDATE_PRODUCT_TYPE_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.UPDATE_PRODUCT_TYPE_SUCCESSFULLY;
            return Ok(Helpers.SerializeObject(response));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpDelete("product-type")]
        public IActionResult DeleteProductType(int productTypeId)
        {
            var kt = _iproductTypeService.DeleteProductType(productTypeId);
            var response = new ResponseDto();

            if (kt) {
                
                response.Message = Constant.DELETE_PRODUCT_TYPE_SUCCESSFULLY;
                return Ok(Helpers.SerializeObject(response));
            }
            response.Message = Constant.DELETE_PRODUCT_TYPE_FAILED;
            return BadRequest(Helpers.SerializeObject(response));                                                                              
        }
    }
}