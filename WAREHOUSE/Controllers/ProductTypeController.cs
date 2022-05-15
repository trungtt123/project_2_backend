using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WareHouse.Service.Interfaces;
using WareHouse.Core.Models;
using WareHouse.Core.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;

namespace WareHouse
{
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
        [HttpGet("listproducttypes")]
        public IActionResult GetListProductTypes()
        {
            var productTypes = _iproductTypeService.GetListProductTypes();
            var response = new ResponseDto();
            if (productTypes == null)
            {

                response.message = Constant.GET_LIST_PRODUCT_TYPES_FAILED;
                return BadRequest(response);
            }
            response.message = Constant.GET_LIST_PRODUCT_TYPES_SUCCESSFULLY;
            response.data = productTypes;
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpGet("producttype")]
        public IActionResult GetProductType(int productTypeId)
        {
            var productType = _iproductTypeService.GetProductType(productTypeId);
            var response = new ResponseDto();
            if (productType == null)
            {
                
                response.message = Constant.GET_PRODUCT_TYPE_FAILED;
                return BadRequest(response);
            }
            response.message = Constant.GET_PRODUCT_TYPE_SUCCESSFULLY;
            response.data = productType;
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPost("producttype")]
        public IActionResult CreateProductType([FromBody] string productTypeName)
        {
            var productType = _iproductTypeService.CreateProductType(productTypeName);
            var response = new ResponseDto();

            if (!productType)
            {
                response.message = Constant.CREATE_USER_FAILED;
                return BadRequest(response);
            }
            response.message = Constant.CREATE_USER_SUCCESSFULLY;
            return Ok(response);
            
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPut("producttype")]
        public IActionResult UpdateProductType(int productTypeId, [FromBody] string newProductTypeName)
        {
            var kt = _iproductTypeService.UpdateProductType(productTypeId, newProductTypeName);
            var response = new ResponseDto();

            if (!kt)
            {
                response.message = Constant.UPDATE_PRODUCT_TYPE_FAILED;
                return BadRequest(response);
            }
            response.message = Constant.UPDATE_PRODUCT_TYPE_SUCCESSFULLY;
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpDelete("producttype")]
        public IActionResult DeleteProductType(int productTypeId)
        {
            var kt = _iproductTypeService.DeleteProductType(productTypeId);
            var response = new ResponseDto();

            if (kt) {
                
                response.message = Constant.DELETE_PRODUCT_TYPE_SUCCESSFULLY;
                return Ok(response);
            }
            response.message = Constant.DELETE_PRODUCT_TYPE_FAILED;
            return BadRequest(response);                                                                              
        }

       
       
    }
}