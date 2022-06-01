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

        public List<ProductBatchProductEntity> GetListProductInProductBatch(int productBatchId)
        {
            try
            {
                var listProducts = new List<ProductBatchProductEntity>();
                using var dbcontext = new MyDbContext();

                listProducts = dbcontext.productBatchProduct.ToList().FindAll(o => o.ProductBatchId == productBatchId);

                return listProducts;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool ProductBatchAddProduct(ProductBatchProductEntity productBatchProduct)
        {
            try
            {
                using var dbcontext = new MyDbContext();

                dbcontext.productBatchProduct.Add(productBatchProduct);

                dbcontext.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool ProductBatchUpdateProduct(ProductBatchProductEntity newProductBatchProduct)
        {
            try
            {
                using var dbcontext = new MyDbContext();

                var row = dbcontext.productBatchProduct
                    .FirstOrDefault(o => o.Id == newProductBatchProduct.Id);
                
                if (row == null) return false;

                row.ProductBatchId = newProductBatchProduct.ProductBatchId;
                row.ProductId = newProductBatchProduct.ProductId;
                row.ProductQuantity = newProductBatchProduct.ProductQuantity;
                row.DateExpiry = newProductBatchProduct.DateExpiry;

                dbcontext.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool ProductBatchRemoveProduct(int id)
        {
            try
            {
                using var dbcontext = new MyDbContext();

                var productBatchProduct = dbcontext.productBatchProduct
                    .FirstOrDefault(o => o.Id == id);

                if (productBatchProduct == null) return false;

                dbcontext.productBatchProduct.Remove(productBatchProduct);
                
                dbcontext.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
        public List<ProductBatchProductEntity> GetListProductBatchProduct()
        {
            try
            {
                using var dbcontext = new MyDbContext();

                var productBatchProduct = dbcontext.productBatchProduct.ToList();
                return productBatchProduct;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
