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
    
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpGet("listproducts")]
        public IActionResult GetListProducts()
        {
            var products = _productService.GetListProducts();
            var response = new ResponseDto();
            if (products == null)
            {

                response.message = Constant.GET_LIST_PRODUCTS_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.message = Constant.GET_LIST_PRODUCTS_SUCCESSFULLY;
            response.data = products;
            return Ok(Helpers.SerializeObject(response));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpGet("product")]
        public IActionResult GetProductType(int productId)
        {
            var productType = _productService.GetProduct(productId);
            var response = new ResponseDto();
            if (productType == null)
            {
                
                response.message = Constant.GET_PRODUCT_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.message = Constant.GET_PRODUCT_SUCCESSFULLY;
            response.data = productType;
            return Ok(Helpers.SerializeObject(response));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPost("product")]
        public IActionResult CreateProductType([FromBody] ProductNoIdDto product)
        {
            var kt = _productService.CreateProduct(product);
            var response = new ResponseDto();

            if (!kt)
            {
                response.message = Constant.CREATE_PRODUCT_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.message = Constant.CREATE_PRODUCT_SUCCESSFULLY;
            return Ok(Helpers.SerializeObject(response));
            
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPut("product")]
        public IActionResult UpdateProductType(int productId, [FromBody] ProductNoIdDto newProductName)
        {
            var kt = _productService.UpdateProduct(productId, newProductName);
            var response = new ResponseDto();

            if (!kt)
            {
                response.message = Constant.UPDATE_PRODUCT_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.message = Constant.UPDATE_PRODUCT_SUCCESSFULLY;
            return Ok(Helpers.SerializeObject(response));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpDelete("product")]
        public IActionResult DeleteProduct(int productId)
        {
            var kt = _productService.DeleteProduct(productId);
            var response = new ResponseDto();

            if (kt) {
                
                response.message = Constant.DELETE_PRODUCT_SUCCESSFULLY;
                return Ok(Helpers.SerializeObject(response));
            }
            response.message = Constant.DELETE_PRODUCT_FAILED;
            return BadRequest(Helpers.SerializeObject(response));                                                                              
        }
    }
}