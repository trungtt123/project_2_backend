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
        [HttpGet("list-products")]
        public IActionResult GetListProducts()
        {
            var products = _productService.GetListProducts();
            var response = new ResponseDto();
            if (products == null)
            {

                response.Message = Constant.GET_LIST_PRODUCTS_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.GET_LIST_PRODUCTS_SUCCESSFULLY;
            response.Data = products;
            return Ok(Helpers.SerializeObject(response));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpGet("product")]
        public IActionResult GetProduct(int productId)
        {
            var product = _productService.GetProduct(productId);
            var response = new ResponseDto();
            if (product == null)
            {
                
                response.Message = Constant.GET_PRODUCT_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.GET_PRODUCT_SUCCESSFULLY;
            response.Data = product;
            return Ok(Helpers.SerializeObject(response));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpPost("product")]
        public IActionResult CreateProduct([FromBody] ProductNoIdDto product)
        {
            var kt = _productService.CreateProduct(product);
            var response = new ResponseDto();

            if (!kt)
            {
                response.Message = Constant.CREATE_PRODUCT_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.CREATE_PRODUCT_SUCCESSFULLY;
            return Ok(Helpers.SerializeObject(response));
            
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpPut("product")]
        public IActionResult UpdateProduct(int productId, [FromBody] ProductNoIdDto newProductName)
        {
            var kt = _productService.UpdateProduct(productId, newProductName);
            var response = new ResponseDto();

            if (!kt)
            {
                response.Message = Constant.UPDATE_PRODUCT_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.UPDATE_PRODUCT_SUCCESSFULLY;
            return Ok(Helpers.SerializeObject(response));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpDelete("product")]
        public IActionResult DeleteProduct(int productId)
        {
            var kt = _productService.DeleteProduct(productId);
            var response = new ResponseDto();

            if (kt) {
                
                response.Message = Constant.DELETE_PRODUCT_SUCCESSFULLY;
                return Ok(Helpers.SerializeObject(response));
            }
            response.Message = Constant.DELETE_PRODUCT_FAILED;
            return BadRequest(Helpers.SerializeObject(response));                                                                              
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpGet("product/list-inventories")]
        public IActionResult GetListInventories()
        {
            var listInventories = _productService.GetListInventory();
            var response = new ResponseDto();
            if (listInventories == null)
            {

                response.Message = Constant.GET_LIST_INVENTORIES_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.GET_LIST_INVENTORIES_SUCCESSFULLY;
            response.Data = listInventories;
            return Ok(Helpers.SerializeObject(response));
        }
    }
}