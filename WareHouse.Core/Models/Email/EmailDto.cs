using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Core.Models
{
    public class EmailFormDto
    {

        [JsonProperty("emailFrom")]
        public string EmailFrom { get; set; }

        [JsonProperty("emailTo")]
        public string EmailTo { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
