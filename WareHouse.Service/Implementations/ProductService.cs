using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Repository.Interfaces;
using WareHouse.Core.Models;
using WareHouse.Core.Entities;
using AutoMapper;
using WareHouse.Service.Interfaces;

namespace WareHouse.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public List<ProductDto> GetListProducts()
        {
            var productEntity = _productRepository.GetListProducts();

            if (productEntity == null) return null;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            var productDto = mapper.Map<List<ProductEntity>, List<ProductDto> >(productEntity);

            return productDto;
        }
        public ProductDto GetProduct(int productId)
        {
            var productEntity = _productRepository.GetProduct(productId);

            if (productEntity == null) return null;
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            var productDto = mapper.Map<ProductEntity, ProductDto>(productEntity);

            return productDto;
        }
        public bool CreateProduct(ProductNoIdDto product)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            var productEntity = mapper.Map<ProductNoIdDto, ProductEntity>(product);

            return _productRepository.CreateProduct(productEntity);
        }
        public bool UpdateProduct(int productId, ProductNoIdDto product)
        {
            var productEntity = _productRepository.GetProduct(productId);
            if (productEntity == null) return false;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            productEntity = mapper.Map<ProductNoIdDto, ProductEntity>(product);
            productEntity.ProductId = productId;

            return _productRepository.UpdateProduct(productEntity);
        }
        public bool DeleteProduct(int productId)
        {
            var productEntity = _productRepository.GetProduct(productId);
            if (productEntity == null) return false;
            return _productRepository.DeleteProduct(productEntity);
        }

    }
}
