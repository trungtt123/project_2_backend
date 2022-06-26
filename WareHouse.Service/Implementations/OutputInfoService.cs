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
    public class OutputInfoService : IOutputInfoService
    {
        private readonly IOutputInfoRepository _outputInfoRepository;

        private readonly IProductRepository _productRepository;

        private readonly IProductBatchRepository _productBatchRepository;

        public OutputInfoService(IOutputInfoRepository outputInfoRepository, IProductRepository productRepository, IProductBatchRepository productBatchRepository)
        {
            _outputInfoRepository = outputInfoRepository;
            _productRepository = productRepository;
            _productBatchRepository = productBatchRepository;
        }
        public List<OutputInfoDto> GetListOutputInfo()
        {
            var outputInfoEntity = _outputInfoRepository.GetListOutputInfo();

            if (outputInfoEntity == null) return null;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            var outputInfoDto = mapper.Map<List<OutputInfoEntity>, List<OutputInfoDto> >(outputInfoEntity);

            return outputInfoDto;
        }
        public OutputInfoDto GetOutputInfo(int outputInfoId)
        {
            var outputInfoEntity = _outputInfoRepository.GetOutputInfo(outputInfoId);

            if (outputInfoEntity == null) return null;

            //var listProductBatches = _outputInfoRepository.GetProductBatchInInputInfo(inputInfoId);

            //if (listProductBatches == null) return null;


            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            var outputInfoDto = mapper.Map<OutputInfoEntity, OutputInfoDto>(outputInfoEntity);

            
            
            var listProductDto = new List<OutputProductDto>();

            var listProductEntity = _outputInfoRepository.GetProductInOutputInfo(outputInfoId);

            listProductDto = mapper.Map <List<OutputProductEntity>, List<OutputProductDto> >(listProductEntity);

            foreach (var productDto in listProductDto)
            {
                var productData = _productBatchRepository.GetProductInProductBatch(productDto.ProductBatchProductId);
                if (productData != null)
                {
                    productDto.ProductId = productData.ProductId;
                    productDto.ProductBatchId = productData.ProductBatchId;
                }
                    
            }
            
            outputInfoDto.ListProducts = listProductDto;

            //foreach (var productBatch in listProductBatches)
            //{
            //    var productBatchEntity = _productBatchRepository.GetProductBatch(productBatch.ProductBatchId);
            //    var productBatchDto = mapper.Map<ProductBatchEntity, ProductBatchDto>(productBatchEntity);
            //    listProductBatchesDto.Add(productBatchDto);
            //}

            //inputInfoDto.ListProductBatches = listProductBatchesDto;

            return outputInfoDto;
        }

        public bool OutputInfoAddProduct(OutputProductNoIdDto outputProduct, int outputInfoId)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            var outputProductEntity = mapper.Map<OutputProductNoIdDto, OutputProductEntity>(outputProduct);

            outputProductEntity.OutputInfoId = outputInfoId;
            var kt = _outputInfoRepository.OutputInfoAddProduct(outputProductEntity);
            return kt;
        }

        public bool OutputInfoUpdateProduct(OutputProductDto outputProduct, int outputInfoId)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            var outputProductEntity = mapper.Map<OutputProductDto, OutputProductEntity>(outputProduct);

            outputProductEntity.OutputInfoId = outputInfoId;

            var kt = _outputInfoRepository.OutputInfoUpdateProduct(outputProductEntity);
            return kt;
        }
        public bool OutputInfoRemoveProduct(int id)
        {

            var kt = _outputInfoRepository.OutputInfoRemoveProduct(id);

            return kt;
        }
        public bool CreateOutputInfo(OutputInfoNoIdDto outputInfo)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            var outputInfoEntity = mapper.Map<OutputInfoNoIdDto, OutputInfoEntity>(outputInfo);

            DateTime now = DateTime.Now;

            outputInfoEntity.OutputCreateTime = now;
            outputInfoEntity.OutputUpdateTime = now;

            return _outputInfoRepository.CreateOutputInfo(outputInfoEntity);
        }
        public bool UpdateOutputInfo(int outputInfoId, OutputInfoNoIdDto newOutputInfo)
        {
            var outputInfoEntity = _outputInfoRepository.GetOutputInfo(outputInfoId);
            if (outputInfoEntity == null) return false;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            outputInfoEntity = mapper.Map<OutputInfoNoIdDto, OutputInfoEntity>(newOutputInfo);
            outputInfoEntity.OutputInfoId = outputInfoId;
            DateTime now = DateTime.Now;
            outputInfoEntity.OutputUpdateTime = now;

            return _outputInfoRepository.UpdateOutputInfo(outputInfoEntity);
        }
        public bool DeleteOutputInfo(int outputInfoId)
        {
            var outputInfoEntity = _outputInfoRepository.GetOutputInfo(outputInfoId);
            if (outputInfoEntity == null) return false;
            return _outputInfoRepository.DeleteOutputInfo(outputInfoEntity);
        }

    }
}
