using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Core.Models;
namespace WareHouse.Service.Interfaces
{
    public interface IProductTypeService
    {
        public List<ProductTypeDto> GetListProductTypes();
        public ProductTypeDto GetProductType(int productTypeId);
        public bool CreateProductType(string productTypeName);
        public bool UpdateProductType(int productTypeId, string newProductTypeName);
        public bool DeleteProductType(int productTypeId);

    }
}
