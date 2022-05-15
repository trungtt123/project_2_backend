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
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypeService(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }
        public List<ProductTypeDto> GetListProductTypes()
        {
            var productTypeEntity = _productTypeRepository.GetListProductTypes();

            if (productTypeEntity == null) return null;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            var productTypeDto = mapper.Map<List<ProductTypeEntity>, List<ProductTypeDto> >(productTypeEntity);

            return productTypeDto;
        }
        public ProductTypeDto GetProductType(int productTypeId)
        {
            var productTypeEntity = _productTypeRepository.GetProductType(productTypeId);

            if (productTypeEntity == null) return null;
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            var productTypeDto = mapper.Map<ProductTypeEntity, ProductTypeDto>(productTypeEntity);

            return productTypeDto;
        }
        public bool CreateProductType(string productTypeName)
        {
           
            var productTypeEntity = new ProductTypeEntity { ProductTypeName = productTypeName };

            return _productTypeRepository.CreateProductType(productTypeEntity);
        }
        public bool UpdateProductType(int productTypeId, string newProductTypeName)
        {
            var productTypeEntity = _productTypeRepository.GetProductType(productTypeId);
            productTypeEntity.ProductTypeName = newProductTypeName;
            return _productTypeRepository.UpdateProductType(productTypeEntity);
        }
        public bool DeleteProductType(int productTypeId)
        {
            var productTypeEntity = _productTypeRepository.GetProductType(productTypeId);
            return _productTypeRepository.DeleteProductType(productTypeEntity);
        }

    }
}
