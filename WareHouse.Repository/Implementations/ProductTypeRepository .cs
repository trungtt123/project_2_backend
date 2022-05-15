using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Repository.Interfaces;
using WareHouse.Core.Entities;

namespace WareHouse.Repository.Implementations
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        public List<ProductTypeEntity> GetListProductTypes()
        {
            try
            {
                using var dbcontext = new MyDbContext();

                var productTypes = new List<ProductTypeEntity>();

                productTypes = dbcontext.productTypes.ToList();

                return productTypes;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ProductTypeEntity GetProductType(int productTypeId)
        {
            try
            {
                using var dbcontext = new MyDbContext();

                var productType = new ProductTypeEntity();

                productType = dbcontext.productTypes.FirstOrDefault(o => o.ProductTypeId == productTypeId);

                return productType;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool CreateProductType(ProductTypeEntity productType)
        {
            try
            {
                using var dbcontext = new MyDbContext();
                dbcontext.productTypes.Add(productType);
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateProductType(ProductTypeEntity newProductType)
        {
            try
            {
                using var dbcontext = new MyDbContext();

                var productType = dbcontext.productTypes.FirstOrDefault(o => o.ProductTypeId == newProductType.ProductTypeId);

                if (productType != null)
                {
                    productType.ProductTypeName = newProductType.ProductTypeName;
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
        public bool DeleteProductType(ProductTypeEntity productType)
        {
            try
            {
                using var dbcontext = new MyDbContext();

                dbcontext.productTypes.Remove(productType);
                
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
