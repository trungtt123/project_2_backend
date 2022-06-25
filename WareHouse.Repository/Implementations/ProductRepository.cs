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
        public ProductEntity GetProduct(int productId)
        {
            try
            {
                using var dbcontext = new MyDbContext();

                var product = new ProductEntity();

                product = dbcontext.products.FirstOrDefault(o => o.ProductId == productId);

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
                using var dbcontext = new MyDbContext();
                dbcontext.products.Add(product);
                dbcontext.SaveChanges();
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
                using var dbcontext = new MyDbContext();

                var product = dbcontext.products.FirstOrDefault(o => o.ProductId == newProduct.ProductId);

                if (product != null)
                {
                    product.ProductName = newProduct.ProductName;
                    product.ProductOrigin = newProduct.ProductOrigin;
                    product.ProductSuplier = newProduct.ProductSuplier;
                    product.ProductTypeId = newProduct.ProductTypeId;
                    product.ProductUnit = newProduct.ProductUnit;

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
        public bool DeleteProduct(ProductEntity product)
        {
            try
            {
                using var dbcontext = new MyDbContext();

                dbcontext.products.Remove(product);

                dbcontext.SaveChanges();

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
                using var dbcontext = new MyDbContext();


                var products = new List<ProductEntity>();

                products = dbcontext.products.ToList();

                return products;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
  
    
}
