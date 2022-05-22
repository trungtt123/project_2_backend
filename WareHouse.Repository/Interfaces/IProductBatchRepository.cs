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
        public bool CreateProductBatch(ProductBatchEntity productBatch);
        public bool UpdateProductBatch(ProductBatchEntity newProductBatch);
        public bool DeleteProductBatch(ProductBatchEntity productBatchId);
        public List<ProductBatchEntity> GetListProductBatches();
    }
}
