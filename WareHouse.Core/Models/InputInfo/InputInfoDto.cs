using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Core.Models
{
    public class InputInfoDto
    {
        [JsonProperty("inputInfoId")]
        public int InputInfoId { get; set; }

        [JsonProperty("inputInfoName")]
        public string InputInfoName { get; set; }
       
        [JsonProperty("inputCreateTime")]
        public DateTime InputCreateTime { get; set; }

        [JsonProperty("inputUpdateTime")]
        public DateTime InputUpdateTime { get; set; }

        [JsonProperty("shipper")]
        public string Shipper { get; set; }

        [JsonProperty("receiverUserId")]
        public int ReceiverUserId { get; set; }

        [JsonProperty("listProductBatches")]
        public List<ProductBatchDto> ListProductBatches { get; set; }

    }
}
