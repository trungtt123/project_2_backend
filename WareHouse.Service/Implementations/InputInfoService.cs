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
    public class InputInfoService : IInputInfoService
    {
        private readonly IInputInfoRepository _inputInfoRepository;

        private readonly IProductBatchRepository _productBatchRepository;

        public InputInfoService(IInputInfoRepository inputInfoRepository, IProductBatchRepository productBatchRepository)
        {
            _inputInfoRepository = inputInfoRepository;
            _productBatchRepository = productBatchRepository;
        }
        public List<InputInfoDto> GetListInputInfo()
        {
            var inputInfoEntity = _inputInfoRepository.GetListInputInfo();

            if (inputInfoEntity == null) return null;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            var inputInfoDto = mapper.Map<List<InputInfoEntity>, List<InputInfoDto> >(inputInfoEntity);

            return inputInfoDto;
        }
        public InputInfoDto GetInputInfo(int inputInfoId)
        {
            var inputInfoEntity = _inputInfoRepository.GetInputInfo(inputInfoId);

            if (inputInfoEntity == null) return null;

            var listProductBatches = _inputInfoRepository.GetProductBatchInInputInfo(inputInfoId);

            if (listProductBatches == null) return null;


            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            var inputInfoDto = mapper.Map<InputInfoEntity, InputInfoDto>(inputInfoEntity);

            var listProductBatchesDto = new List<ProductBatchDto>();
            
            foreach (var productBatch in listProductBatches)
            {
                var productBatchEntity = _productBatchRepository.GetProductBatch(productBatch.ProductBatchId);
                var productBatchDto = mapper.Map<ProductBatchEntity, ProductBatchDto>(productBatchEntity);
                listProductBatchesDto.Add(productBatchDto);
            }

            inputInfoDto.ListProductBatches = listProductBatchesDto;

            return inputInfoDto;
        }

        public bool InputInfoAddProductBatch(int productBatchId, int inputInfoId)
        {
            var kt = _inputInfoRepository.InputInfoAddProductBatch(productBatchId, inputInfoId);
            return kt;
        }
        public bool InputInfoRemoveProductBatch(int productBatchId)
        { 
            
            var kt = _inputInfoRepository.InputInfoRemoveProductBatch(productBatchId);

            return kt;
        }
        public bool CreateInputInfo(InputInfoNoIdDto inputInfo)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            var inputInfoEntity = mapper.Map<InputInfoNoIdDto, InputInfoEntity>(inputInfo);

            DateTime now = DateTime.Now;

            inputInfoEntity.InputCreateTime = now;
            inputInfoEntity.InputUpdateTime = now;

            return _inputInfoRepository.CreateInputInfo(inputInfoEntity);
        }
        public bool UpdateInputInfo(int inputInfoId, InputInfoNoIdDto newInputInfo)
        {
            var inputInfoEntity = _inputInfoRepository.GetInputInfo(inputInfoId);
            if (inputInfoEntity == null) return false;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            inputInfoEntity = mapper.Map<InputInfoNoIdDto, InputInfoEntity>(newInputInfo);
            inputInfoEntity.InputInfoId = inputInfoId;
            DateTime now = DateTime.Now;
            inputInfoEntity.InputUpdateTime = now;

            return _inputInfoRepository.UpdateInputInfo(inputInfoEntity);
        }
        public bool DeleteInputInfo(int inputInfoId)
        {
            var inputInfoEntity = _inputInfoRepository.GetInputInfo(inputInfoId);
            if (inputInfoEntity == null) return false;
            return _inputInfoRepository.DeleteInputInfo(inputInfoEntity);
        }

    }
}
