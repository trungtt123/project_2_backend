using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Core.Entities;

namespace WareHouse.Repository.Interfaces
{
    public interface IProductBatchRepository
    {
        public ProductBatchEntity GetProductBatch(int productBatchId);
        public List<ProductBatchProductEntity> GetListProductInProductBatch(int productBatchId);
        public List<ProductBatchProductEntity> GetListProductBatchProduct();
        public bool ProductBatchAddProduct(ProductBatchProductEntity productBatchProduct);
        public bool ProductBatchUpdateProduct(ProductBatchProductEntity newProductBatchProduct);
        public bool ProductBatchRemoveProduct(int productBatchId, int productId);

        public bool CreateProductBatch(ProductBatchEntity productBatch);
        public bool UpdateProductBatch(ProductBatchEntity newProductBatch);
        public bool DeleteProductBatch(ProductBatchEntity productBatchId);
        public List<ProductBatchEntity> GetListProductBatches();
    }
}
