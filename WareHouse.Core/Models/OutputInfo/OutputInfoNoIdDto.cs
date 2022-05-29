using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Core.Models
{
    public class OutputInfoNoIdDto
    {

        [JsonProperty("outputInfoName")]
        public string OutputInfoName { get; set; }

        [JsonProperty("pickerId")]
        public int PickerId { get; set; }

        [JsonProperty("signatorId")]
        public int SignatorId { get; set; }

    }
}
