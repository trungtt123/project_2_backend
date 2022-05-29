using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Core.Models;
namespace WareHouse.Service.Interfaces
{
    public interface IProductBatchService
    {
        public List<ProductBatchDto> GetListProductBatches();
        public ProductBatchDto GetProductBatch(int productBatchId);
        public bool ProductBatchAddProduct(int productBatchId, int productId, ProductBatchProductNoIdDto productBatchProduct);
        public bool ProductBatchUpdateProduct(int productBatchId, int productId, ProductBatchProductNoIdDto newProductBatchProduct);
        public bool ProductBatchRemoveProduct(int productBatchId, int productId);
        public bool CreateProductBatch(ProductBatchNoIdDto productBatch);
        public bool UpdateProductBatch(int productBatchId, ProductBatchNoIdDto productBatch);
        public bool DeleteProductBatch(int productBatchId);

    }
}
