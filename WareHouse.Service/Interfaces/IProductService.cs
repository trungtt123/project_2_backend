using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Core.Models;
namespace WareHouse.Service.Interfaces
{
    public interface IProductService
    {
        public List<ProductDto> GetListProducts();
        public ProductDto GetProduct(int productId);
        public bool CreateProduct(ProductNoIdDto product);
        public bool UpdateProduct(int productId, ProductNoIdDto product);
        public bool DeleteProduct(int productId);
        public List<InventoryDto> GetListInventory();

    }
}
