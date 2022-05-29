using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Core.Models
{
    public class OutputInfoDto
    {
        [JsonProperty("outputInfoId")]
        public int OutputInfoId { get; set; }

        [JsonProperty("outputInfoName")]
        public string OutputInfoName { get; set; }

        [JsonProperty("outputCreateTime")]
        public DateTime OutputCreateTime { get; set; }

        [JsonProperty("outputUpdateTime")]
        public DateTime OutputUpdateTime { get; set; }

        [JsonProperty("pickerId")]
        public int PickerId { get; set; }

        [JsonProperty("signatorId")]
        public int SignatorId { get; set; }
        
        [JsonProperty("listProducts")]
        public List<OutputProductDto> ListProducts { get; set; }
    }
}
