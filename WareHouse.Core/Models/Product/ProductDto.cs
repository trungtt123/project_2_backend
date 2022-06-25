using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Core.Models
{
    public class ProductDto
    {
        [JsonProperty("productId")]
        public int ProductId { get; set; }

        [JsonProperty("productName")]
        public string ProductName { get; set; }

        [JsonProperty("productOrigin")]
        public string ProductOrigin { get; set; }

        [JsonProperty("productSuplier")]
        public string ProductSuplier { get; set; }

        [JsonProperty("productTypeId")]
        public int ProductTypeId { get; set; }

        [JsonProperty("productUnit")]
        public string ProductUnit { get; set; }
    }
}
