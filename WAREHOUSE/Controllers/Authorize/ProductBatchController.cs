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
    
    public class ProductBatchController : ControllerBase
    {
        private readonly IProductBatchService _productBatchService;
        public ProductBatchController(IProductBatchService productBatchService)
        {
            _productBatchService = productBatchService;

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpGet("list-product-batches")]
        public IActionResult GetListProductBatches()
        {
            var products = _productBatchService.GetListProductBatches();
            var response = new ResponseDto();
            if (products == null)
            {

                response.Message = Constant.GET_LIST_PRODUCT_BATCHES_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.GET_LIST_PRODUCT_BATCHES_SUCCESSFULLY;
            response.Data = products;
            return Ok(Helpers.SerializeObject(response));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpGet("product-batch")]
        public IActionResult GetProductBatch(int productBatchId)
        {
            var productBatch = _productBatchService.GetProductBatch(productBatchId);
            var response = new ResponseDto();
            if (productBatch == null)
            {
                
                response.Message = Constant.GET_PRODUCT_BATCH_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.GET_PRODUCT_BATCH_SUCCESSFULLY;
            response.Data = productBatch;
            return Ok(Helpers.SerializeObject(response));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPost("product-batch")]
        public IActionResult CreateProductBatch([FromBody] ProductBatchNoIdDto productBatch)
        {
            var kt = _productBatchService.CreateProductBatch(productBatch);
            var response = new ResponseDto();

            if (!kt)
            {
                response.Message = Constant.CREATE_PRODUCT_BATCH_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.CREATE_PRODUCT_BATCH_SUCCESSFULLY;
            return Ok(Helpers.SerializeObject(response));
            
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPut("product-batch")]
        public IActionResult UpdateProductType(int productBatchId, [FromBody] ProductBatchNoIdDto newProductBatch)
        {
            var kt = _productBatchService.UpdateProductBatch(productBatchId, newProductBatch);
            var response = new ResponseDto();

            if (!kt)
            {
                response.Message = Constant.UPDATE_PRODUCT_BATCH_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.Message = Constant.UPDATE_PRODUCT_BATCH_SUCCESSFULLY;
            return Ok(Helpers.SerializeObject(response));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpDelete("product-batch")]
        public IActionResult DeleteProductBatch(int productBatchId)
        {
            var kt = _productBatchService.DeleteProductBatch(productBatchId);
            var response = new ResponseDto();

            if (kt) {
                
                response.Message = Constant.DELETE_PRODUCT_BATCH_SUCCESSFULLY;
                return Ok(Helpers.SerializeObject(response));
            }
            response.Message = Constant.DELETE_PRODUCT_BATCH_FAILED;
            return BadRequest(Helpers.SerializeObject(response));                                                                              
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPost("product-batch/products")]
        public IActionResult ProductBatchAddProduct([FromBody] ProductBatchProductNoIdDto data)
        {
            var kt = _productBatchService.ProductBatchAddProduct(data);
            var response = new ResponseDto();

            if (kt)
            {

                response.Message = Constant.PRODUCT_BATCHE_ADD_PRODUCT_SUCCESSFULLY;
                return Ok(Helpers.SerializeObject(response));
            }
            response.Message = Constant.PRODUCT_BATCHE_ADD_PRODUCT_FAILED;
            return BadRequest(Helpers.SerializeObject(response));
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPut("product-batch/products")]
        public IActionResult ProductBatchUpdateProduct(int id, [FromBody] ProductBatchProductNoIdDto data)
        {
            var kt = _productBatchService.ProductBatchUpdateProduct(id, data);
            var response = new ResponseDto();

            if (kt)
            {

                response.Message = Constant.PRODUCT_BATCHE_UPDATE_PRODUCT_SUCCESSFULLY;
                return Ok(Helpers.SerializeObject(response));
            }
            response.Message = Constant.PRODUCT_BATCHE_UPDATE_PRODUCT_FAILED;
            return BadRequest(Helpers.SerializeObject(response));
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpDelete("product-batch/products")]
        public IActionResult ProductBatchRemoveProduct(int id)
        {
            var kt = _productBatchService.ProductBatchRemoveProduct(id);
            var response = new ResponseDto();

            if (kt)
            {

                response.Message = Constant.PRODUCT_BATCHE_REMOVE_PRODUCT_SUCCESSFULLY;
                return Ok(Helpers.SerializeObject(response));
            }
            response.Message = Constant.PRODUCT_BATCHE_REMOVE_PRODUCT_FAILED;
            return BadRequest(Helpers.SerializeObject(response));
        }
    }
}