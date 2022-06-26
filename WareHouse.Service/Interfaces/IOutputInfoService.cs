using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Core.Models;
namespace WareHouse.Service.Interfaces
{
    public interface IOutputInfoService
    {
        public List<OutputInfoDto> GetListOutputInfo();
        public OutputInfoDto GetOutputInfo(int outputInfoId);
        public bool OutputInfoAddProduct(OutputProductNoIdDto outputProduct, int outputInfoId);

        public bool OutputInfoUpdateProduct(OutputProductNoIdDto newOutputProduct, int outputInfoId);
        public bool OutputInfoRemoveProduct(int id);
        public bool CreateOutputInfo(OutputInfoNoIdDto outputInfo);
        public bool UpdateOutputInfo(int outputInfoId, OutputInfoNoIdDto newOutputInfo);
        public bool DeleteOutputInfo(int outputInfoId);

    }
}
