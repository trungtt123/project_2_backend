using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Core.Models;
namespace WareHouse.Service.Interfaces
{
    public interface IInputInfoService
    {
        public List<InputInfoDto> GetListInputInfo();
        public InputInfoDto GetInputInfo(int inputInfoId);
        public bool InputInfoAddProductBatch(int productBatchId, int inputInfoId);
        public bool InputInfoRemoveProductBatch(int productBatchId);
        public bool CreateInputInfo(InputInfoNoIdDto inputInfo);
        public bool UpdateInputInfo(int inputInfoId, InputInfoNoIdDto newInputInfo);
        public bool DeleteInputInfo(int inputInfoId);

    }
}
