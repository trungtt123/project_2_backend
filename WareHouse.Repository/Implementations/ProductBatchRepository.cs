using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Repository.Interfaces;
using WareHouse.Core.Entities;

namespace WareHouse.Repository.Implementations
{
    public class ProductBatchRepository : IProductBatchRepository
    {
        public List<ProductBatchEntity> GetListProductBatches()
        {
            try
            {
                using var dbcontext = new MyDbContext();

                var productBatches = new List<ProductBatchEntity>();

                productBatches = dbcontext.productBatches.ToList();

                return productBatches;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ProductBatchEntity GetProductBatch(int productBatchId)
        {
            try
            {
                using var dbcontext = new MyDbContext();

                var productBatch = new ProductBatchEntity();

                productBatch = dbcontext.productBatches.FirstOrDefault(o => o.ProductBatchId == productBatchId);

                return productBatch;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool CreateProductBatch(ProductBatchEntity productBatch)
        {
            try
            {
                using var dbcontext = new MyDbContext();
                dbcontext.productBatches.Add(productBatch);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateProductBatch(ProductBatchEntity newProductBatch)
        {
            try
            {
                using var dbcontext = new MyDbContext();

                var productBatch = dbcontext.productBatches.FirstOrDefault(o => o.ProductBatchId == newProductBatch.ProductBatchId);

                if (productBatch != null)
                {
                    productBatch.ProductBatchName = newProductBatch.ProductBatchName;
                    productBatch.ProductId = newProductBatch.ProductId;
                    productBatch.ProductQuantity = newProductBatch.ProductQuantity;
                    productBatch.DateExpiry = newProductBatch.DateExpiry;
                    dbcontext.SaveChanges();
                    return true;
                }
                else return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteProductBatch(ProductBatchEntity productBatch)
        {
            try
            {
                using var dbcontext = new MyDbContext();

                dbcontext.productBatches.Remove(productBatch);
                
                dbcontext.SaveChanges();
                
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
