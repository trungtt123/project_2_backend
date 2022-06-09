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
        private readonly IProductBatchRepository _productBatchRepository;
        private readonly IOutputInfoRepository _outputInfoRepository;
        public ProductService(IProductRepository productRepository, IProductBatchRepository productBatchRepository, IOutputInfoRepository outputInfoRepository)
        {
            _productRepository = productRepository;
            _productBatchRepository = productBatchRepository;
            _outputInfoRepository = outputInfoRepository;
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
        public List<InventoryDto> GetListInventory()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            

            var listInventories = new List<InventoryDto>();
            var listProducts = new List<ProductEntity>();

            var listProductBatchProduct = _productBatchRepository.GetListProductBatchProduct();
            listProducts = _productRepository.GetListProducts();

            foreach (var product in listProducts)
            {
                var inventory = new InventoryDto();
                inventory.ProductId = product.ProductId;
                var productBatchProduct = listProductBatchProduct
                    .FindAll(o =>
                    {
                        var productBatchId = o.ProductBatchId;
                        var productBatch = _productBatchRepository.GetProductBatch(productBatchId);
                        return o.ProductId == product.ProductId && !(productBatch.InputInfoId == null || productBatch.InputInfoId == 0);
                    });
                var inv = mapper.Map<List<ProductBatchProductEntity>, List<ProductBatchInVentory>>(productBatchProduct);
                var listOutputProductEntity = _outputInfoRepository.GetProductById(product.ProductId);
                var listOutputProductDto = mapper.Map<List<OutputProductEntity>, List<OutputProductDto>>(listOutputProductEntity);
                var exported = GetTotalExportedInProductBatch(listOutputProductDto);
                inventory.ListProductBatches = inv;
                inventory.Exported = exported;
                inventory.Total = GetTotalProductQuantityInProductBatch(inv);
                inventory.ListProductExported = listOutputProductDto;
                
                listInventories.Add(inventory);
            }
            return listInventories;
        }
        public static int GetTotalProductQuantityInProductBatch(List<ProductBatchInVentory> arr)
        {
            try
            {
                var total = 0;

                foreach (var item in arr)
                {
                    total += item.ProductQuantity;
                }
                return total;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static int GetTotalExportedInProductBatch(List<OutputProductDto> arr)
        {
            try
            {
                var total = 0;

                foreach (var item in arr)
                {
                    total += item.ProductQuantity;
                }
                return total;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}
