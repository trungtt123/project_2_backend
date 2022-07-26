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
        private readonly MyDbContext _dbcontext;

        public ProductBatchRepository()
        {
            _dbcontext = new MyDbContext();
        }
        public List<ProductBatchEntity> GetListProductBatches()
        {
            try
            {

                var productBatches = new List<ProductBatchEntity>();

                productBatches = _dbcontext.ProductBatches.ToList();

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

                var productBatch = new ProductBatchEntity();

                productBatch = _dbcontext.ProductBatches.FirstOrDefault(o => o.ProductBatchId == productBatchId);

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
                _dbcontext.ProductBatches.Add(productBatch);

                var inputInfo = _dbcontext.InputInfo.FirstOrDefault(o => o.InputInfoId == productBatch.InputInfoId);
                if (inputInfo != null)
                {
                    inputInfo.InputUpdateTime = DateTime.Now;
                    _dbcontext.SaveChanges();
                }

                _dbcontext.SaveChanges();
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

                var productBatch = _dbcontext.ProductBatches.FirstOrDefault(o => o.ProductBatchId == newProductBatch.ProductBatchId);

                if (productBatch != null)
                {
                    productBatch.ProductBatchName = newProductBatch.ProductBatchName;
                    _dbcontext.SaveChanges();

                    var inputInfo = _dbcontext.InputInfo.FirstOrDefault(o => o.InputInfoId == productBatch.InputInfoId);
                    if (inputInfo != null)
                    {
                        inputInfo.InputUpdateTime = DateTime.Now;
                        _dbcontext.SaveChanges();
                    }

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
                _dbcontext.ProductBatches.Remove(productBatch);
                
                _dbcontext.SaveChanges();

                var inputInfo = _dbcontext.InputInfo.FirstOrDefault(o => o.InputInfoId == productBatch.InputInfoId);
                if (inputInfo != null)
                {
                    inputInfo.InputUpdateTime = DateTime.Now;
                    _dbcontext.SaveChanges();
                }

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
                
                listProducts = _dbcontext.ProductBatchProduct.ToList().FindAll(o => o.ProductBatchId == productBatchId);

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

                _dbcontext.ProductBatchProduct.Add(productBatchProduct);

                _dbcontext.SaveChanges();

                var productBatch = _dbcontext.ProductBatches.FirstOrDefault(o => o.ProductBatchId == productBatchProduct.ProductBatchId);
                var inputInfo = _dbcontext.InputInfo.FirstOrDefault(o => o.InputInfoId == productBatch.InputInfoId);
                if (inputInfo != null)
                {
                    inputInfo.InputUpdateTime = DateTime.Now;
                    _dbcontext.SaveChanges();
                }
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

                var row = _dbcontext.ProductBatchProduct
                    .FirstOrDefault(o => o.Id == newProductBatchProduct.Id);
                
                if (row == null) return false;

                row.ProductBatchId = newProductBatchProduct.ProductBatchId;
                row.ProductId = newProductBatchProduct.ProductId;
                row.ProductQuantity = newProductBatchProduct.ProductQuantity;
                row.DateExpiry = newProductBatchProduct.DateExpiry;

                _dbcontext.SaveChanges();

                var productBatch = _dbcontext.ProductBatches.FirstOrDefault(o => o.ProductBatchId == newProductBatchProduct.ProductBatchId);
                var inputInfo = _dbcontext.InputInfo.FirstOrDefault(o => o.InputInfoId == productBatch.InputInfoId);
                if (inputInfo != null)
                {
                    inputInfo.InputUpdateTime = DateTime.Now;
                    _dbcontext.SaveChanges();
                }

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

                var productBatchProduct = _dbcontext.ProductBatchProduct
                    .FirstOrDefault(o => o.Id == id);

                if (productBatchProduct == null) return false;

                _dbcontext.ProductBatchProduct.Remove(productBatchProduct);
                
                _dbcontext.SaveChanges();

                var productBatch = _dbcontext.ProductBatches.FirstOrDefault(o => o.ProductBatchId == productBatchProduct.ProductBatchId);
                var inputInfo = _dbcontext.InputInfo.FirstOrDefault(o => o.InputInfoId == productBatch.InputInfoId);
                if (inputInfo != null)
                {
                    inputInfo.InputUpdateTime = DateTime.Now;
                    _dbcontext.SaveChanges();
                }


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
                
                var productBatchProduct = _dbcontext.ProductBatchProduct.ToList();
                return productBatchProduct;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ProductBatchProductEntity GetProductInProductBatch(int id)
        {
            try
            {
              
                var productBatchProduct = _dbcontext.ProductBatchProduct.FirstOrDefault(o => o.Id == id);
                return productBatchProduct;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
