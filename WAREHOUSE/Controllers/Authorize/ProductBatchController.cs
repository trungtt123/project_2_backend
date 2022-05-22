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
        [HttpGet("listproductbatches")]
        public IActionResult GetListProductBatches()
        {
            var products = _productBatchService.GetListProductBatches();
            var response = new ResponseDto();
            if (products == null)
            {

                response.message = Constant.GET_LIST_PRODUCT_BATCHES_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.message = Constant.GET_LIST_PRODUCT_BATCHES_SUCCESSFULLY;
            response.data = products;
            return Ok(Helpers.SerializeObject(response));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator + ", " + Constant.Manager + ", " + Constant.Stocker)]
        [HttpGet("productbatch")]
        public IActionResult GetProductBatch(int productBatchId)
        {
            var productBatch = _productBatchService.GetProductBatch(productBatchId);
            var response = new ResponseDto();
            if (productBatch == null)
            {
                
                response.message = Constant.GET_PRODUCT_BATCH_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.message = Constant.GET_PRODUCT_BATCH_SUCCESSFULLY;
            response.data = productBatch;
            return Ok(Helpers.SerializeObject(response));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPost("productbatch")]
        public IActionResult CreateProductBatch([FromBody] ProductBatchNoIdDto productBatch)
        {
            var kt = _productBatchService.CreateProductBatch(productBatch);
            var response = new ResponseDto();

            if (!kt)
            {
                response.message = Constant.CREATE_PRODUCT_BATCH_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.message = Constant.CREATE_PRODUCT_BATCH_SUCCESSFULLY;
            return Ok(Helpers.SerializeObject(response));
            
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpPut("productbatch")]
        public IActionResult UpdateProductType(int productId, [FromBody] ProductBatchNoIdDto newProductBatch)
        {
            var kt = _productBatchService.UpdateProductBatch(productId, newProductBatch);
            var response = new ResponseDto();

            if (!kt)
            {
                response.message = Constant.UPDATE_PRODUCT_BATCH_FAILED;
                return BadRequest(Helpers.SerializeObject(response));
            }
            response.message = Constant.UPDATE_PRODUCT_BATCH_SUCCESSFULLY;
            return Ok(Helpers.SerializeObject(response));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = Constant.Administrator)]
        [HttpDelete("productbatch")]
        public IActionResult DeleteProductBatch(int productBatchId)
        {
            var kt = _productBatchService.DeleteProductBatch(productBatchId);
            var response = new ResponseDto();

            if (kt) {
                
                response.message = Constant.DELETE_PRODUCT_BATCH_SUCCESSFULLY;
                return Ok(Helpers.SerializeObject(response));
            }
            response.message = Constant.DELETE_PRODUCT_BATCH_FAILED;
            return BadRequest(Helpers.SerializeObject(response));                                                                              
        }
    }
}