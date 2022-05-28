using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Core.Models
{
    public class ProductTypeDto
    {
        [JsonProperty("productTypeId")]
        public string ProductTypeId { get; set; }

        [JsonProperty("productTypeName")]
        public string ProductTypeName { get; set; }
    }
}
