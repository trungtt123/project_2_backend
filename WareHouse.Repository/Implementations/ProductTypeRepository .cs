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
        private readonly MyDbContext _dbcontext;

        public ProductTypeRepository()
        {
            _dbcontext = new MyDbContext();
        }
        public List<ProductTypeEntity> GetListProductTypes()
        {
            try
            {

                var productTypes = new List<ProductTypeEntity>();

                productTypes = _dbcontext.ProductTypes.ToList();

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

                var productType = new ProductTypeEntity();

                productType = _dbcontext.ProductTypes.FirstOrDefault(o => o.ProductTypeId == productTypeId);

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
                _dbcontext.ProductTypes.Add(productType);
                _dbcontext.SaveChanges();
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

                var productType = _dbcontext.ProductTypes.FirstOrDefault(o => o.ProductTypeId == newProductType.ProductTypeId);

                if (productType != null)
                {
                    productType.ProductTypeName = newProductType.ProductTypeName;
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
        public bool DeleteProductType(ProductTypeEntity productType)
        {
            try
            {
                _dbcontext.ProductTypes.Remove(productType);
                
                _dbcontext.SaveChanges();
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
