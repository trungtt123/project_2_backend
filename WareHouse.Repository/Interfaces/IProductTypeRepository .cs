using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Core.Entities;
using WareHouse.Core.Models;

namespace WareHouse.Repository.Interfaces
{
    public interface IProductTypeRepository
    {
        public ProductTypeEntity GetProductType(int productTypeId);
        public bool CreateProductType(ProductTypeEntity productType);
        public bool UpdateProductType(ProductTypeEntity newProductType);
        public bool DeleteProductType(ProductTypeEntity productTypeId);
        public List<ProductTypeEntity> GetListProductTypes();

    }
}
