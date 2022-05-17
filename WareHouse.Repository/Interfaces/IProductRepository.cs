using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Core.Entities;

namespace WareHouse.Repository.Interfaces
{
    public interface IProductRepository
    {
        public ProductEntity GetProduct(int productId);
        public bool CreateProduct(ProductEntity product);
        public bool UpdateProduct(ProductEntity newProduct);
        public bool DeleteProduct(ProductEntity productId);
        public List<ProductEntity> GetListProducts();
    }
}
