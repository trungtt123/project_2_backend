using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Core.Models
{
    public class ProductBatchDto
    {
        [JsonProperty("productBatchId")]
        public int ProductBatchId { get; set; }

        [JsonProperty("productBatchName")]
        public string ProductBatchName { get; set; }

        [JsonProperty("productId")]
        public int ProductId { get; set; }

        [JsonProperty("productQuantity")]
        public int ProductQuantity { get; set; }

        [JsonProperty("dateExpiry")]
        public DateTime DateExpiry { get; set; }

        [JsonProperty("inputInfoId")]
        public int InputInfoId { get; set; }
    }
}
