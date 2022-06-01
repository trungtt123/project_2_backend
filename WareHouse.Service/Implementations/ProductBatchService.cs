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
    public class ProductBatchService : IProductBatchService
    {
        private readonly IProductBatchRepository _productBatchRepository;

        private readonly IInputInfoRepository _inputInfoRepository;

        public ProductBatchService(IProductBatchRepository productBatchRepository, IInputInfoRepository inputInfoRepository)
        {
            _productBatchRepository = productBatchRepository;
            _inputInfoRepository = inputInfoRepository;
        }
        public List<ProductBatchDto> GetListProductBatches()
        {
            var productBatchEntity = _productBatchRepository.GetListProductBatches();

            if (productBatchEntity == null) return null;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            var productBatchDto = mapper.Map<List<ProductBatchEntity>, List<ProductBatchDto>>(productBatchEntity);

            return productBatchDto;
        }
        public ProductBatchDto GetProductBatch(int productBatchId)
        {
            var productBatchEntity = _productBatchRepository.GetProductBatch(productBatchId);

            if (productBatchEntity == null) return null;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            var productBatchDto = mapper.Map<ProductBatchEntity, ProductBatchDto>(productBatchEntity);
            var listProductEntity = _productBatchRepository.GetListProductInProductBatch(productBatchId);

            var listProductDto = mapper.Map<List<ProductBatchProductEntity>, List<ProductBatchProductDto> >(listProductEntity);
            
            productBatchDto.ListProducts = listProductDto;

            return productBatchDto;
        }
        public bool CreateProductBatch(ProductBatchNoIdDto productBatch)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            var productBatchEntity = mapper.Map<ProductBatchNoIdDto, ProductBatchEntity>(productBatch);

            return _productBatchRepository.CreateProductBatch(productBatchEntity);
        }
        public bool UpdateProductBatch(int productBatchId, ProductBatchNoIdDto productBatch)
        {
            var productBatchEntity = _productBatchRepository.GetProductBatch(productBatchId);
            if (productBatchEntity == null) return false;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            productBatchEntity = mapper.Map<ProductBatchNoIdDto, ProductBatchEntity>(productBatch);
            productBatchEntity.ProductBatchId = productBatchId;

            return _productBatchRepository.UpdateProductBatch(productBatchEntity);
        }
        public bool DeleteProductBatch(int productBatchId)
        {
            var productBatchEntity = _productBatchRepository.GetProductBatch(productBatchId);
            if (productBatchEntity == null) return false;
            return _productBatchRepository.DeleteProductBatch(productBatchEntity);
        }
        public bool ProductBatchAddProduct(ProductBatchProductNoIdDto productBatchProduct)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            var productBatchProductEntity = mapper.Map<ProductBatchProductNoIdDto, ProductBatchProductEntity>(productBatchProduct);

            return _productBatchRepository.ProductBatchAddProduct(productBatchProductEntity);
        }
        public bool ProductBatchUpdateProduct(int id, ProductBatchProductNoIdDto newProductBatchProduct)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();
            var productBatchProductEntity = mapper.Map<ProductBatchProductNoIdDto, ProductBatchProductEntity>(newProductBatchProduct);
            productBatchProductEntity.Id = id;
            return _productBatchRepository.ProductBatchUpdateProduct(productBatchProductEntity);
        }
        public bool ProductBatchRemoveProduct(int id)
        {
            return _productBatchRepository.ProductBatchRemoveProduct(id);
        }
    }
}
