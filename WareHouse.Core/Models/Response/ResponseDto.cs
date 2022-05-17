using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Core.Models
{
    public class ResponseDto
    {
        public string message { get; set; }

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public object data { get; set; }
    }
}
