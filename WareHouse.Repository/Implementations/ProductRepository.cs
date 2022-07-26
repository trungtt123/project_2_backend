using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Core.Entities;
using WareHouse.Repository.Interfaces;

namespace WareHouse.Repository.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDbContext _dbcontext;

        public ProductRepository()
        {
            _dbcontext = new MyDbContext();
        }
        public ProductEntity GetProduct(int productId)
        {
            try
            {
                var product = new ProductEntity();

                product = _dbcontext.Products.FirstOrDefault(o => o.ProductId == productId);

                return product;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool CreateProduct(ProductEntity product)
        {
            try
            {
                _dbcontext.Products.Add(product);
                _dbcontext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateProduct(ProductEntity newProduct)
        {
            try
            {

                var product = _dbcontext.Products.FirstOrDefault(o => o.ProductId == newProduct.ProductId);

                if (product != null)
                {
                    product.ProductName = newProduct.ProductName;
                    product.ProductOrigin = newProduct.ProductOrigin;
                    product.ProductSuplier = newProduct.ProductSuplier;
                    product.ProductTypeId = newProduct.ProductTypeId;
                    product.ProductUnit = newProduct.ProductUnit;

                    _dbcontext.SaveChanges();
                    return true;
                }
                else return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteProduct(ProductEntity product)
        {
            try
            {

                _dbcontext.Products.Remove(product);

                _dbcontext.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<ProductEntity> GetListProducts()
        {
            try
            {
                var products = new List<ProductEntity>();

                products = _dbcontext.Products.ToList();

                return products;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
  
    
}
