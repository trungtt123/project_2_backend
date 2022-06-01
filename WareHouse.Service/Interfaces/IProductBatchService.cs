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
        public bool ProductBatchAddProduct(ProductBatchProductNoIdDto productBatchProduct);
        public bool ProductBatchUpdateProduct(int id, ProductBatchProductNoIdDto newProductBatchProduct);
        public bool ProductBatchRemoveProduct(int id);
        public bool CreateProductBatch(ProductBatchNoIdDto productBatch);
        public bool UpdateProductBatch(int productBatchId, ProductBatchNoIdDto productBatch);
        public bool DeleteProductBatch(int productBatchId);

    }
}
