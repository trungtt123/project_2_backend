using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Core.Models
{
    public class EmailAccountDto
    {
        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }
        
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
