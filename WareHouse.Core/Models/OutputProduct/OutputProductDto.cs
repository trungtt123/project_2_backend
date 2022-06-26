using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Core.Models
{
    public class OutputProductDto
    {
        [JsonProperty("outputProductId")]
        public int Id { get; set; }
        
        [JsonProperty("productBatchProductId")]
        public int ProductBatchProductId { get; set; }

        [JsonProperty("productId")]
        public int ProductId { get; set; }

        [JsonProperty("productBatchId")]
        public int ProductBatchId { get; set; }

        [JsonProperty("dateExpiry")]
        public DateTime DateExpiry { get; set; }

        [JsonProperty("productQuantity")]
        public int ProductQuantity { get; set; }
    }
}
