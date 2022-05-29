using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WareHouse.Core.Models
{
    public class ProductBatchProductNoIdDto
    {

        [JsonProperty("productQuantity")]
        public int ProductQuantity { get; set; }

        [JsonProperty("dateExpiry")]
        public DateTime DateExpiry { get; set; }


    }
}
