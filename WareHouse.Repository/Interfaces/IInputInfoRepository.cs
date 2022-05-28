using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Core.Entities;

namespace WareHouse.Repository.Interfaces
{
    public interface IInputInfoRepository
    {
        public InputInfoEntity GetInputInfo(int inputInfoId);
        public List<ProductBatchEntity> GetProductBatchInInputInfo(int inputInfoId);
        public bool InputInfoAddProductBatch(int productBatchId, int inputInfoId);
        public bool InputInfoRemoveProductBatch(int productBatchId);
        public bool CreateInputInfo(InputInfoEntity inputInfo);
        public bool UpdateInputInfo(InputInfoEntity newInputInfo);
        public bool DeleteInputInfo(InputInfoEntity inputInfoId);
        public List<InputInfoEntity> GetListInputInfo();
    }
}
