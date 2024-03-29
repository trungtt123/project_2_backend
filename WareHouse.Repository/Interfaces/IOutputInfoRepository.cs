﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Core.Entities;

namespace WareHouse.Repository.Interfaces
{
    public interface IOutputInfoRepository
    {
        public OutputInfoEntity GetOutputInfo(int outputInfoId);

        public List<OutputProductEntity> GetProductInOutputInfo(int outputInfoId);

        public List<OutputProductEntity> GetProductInOutputById(int productBatchProductId);
        public bool OutputInfoAddProduct(OutputProductEntity outputProductEntity);

        public bool OutputInfoUpdateProduct(OutputProductEntity newOutputProduct);
        public bool OutputInfoRemoveProduct(int id);
        public bool CreateOutputInfo(OutputInfoEntity outputInfo);
        public bool UpdateOutputInfo(OutputInfoEntity newOutputInfo);
        public bool DeleteOutputInfo(OutputInfoEntity outputInfoId);
        public List<OutputInfoEntity> GetListOutputInfo();
    }
}
