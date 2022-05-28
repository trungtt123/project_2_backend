using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Core.Models
{
    public class InputInfoNoIdDto
    {
        [JsonProperty("inputInfoName")]
        public string InputInfoName { get; set; } 

        [JsonProperty("shipper")]
        public string Shipper { get; set; }

        [JsonProperty("receiverUserId")]
        public int ReceiverUserId { get; set; }

    }
}
