using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Core.Models
{
    public class InventoryDto
    {
        [JsonProperty("productId")]
        public int ProductId { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("exported")]
        public int Exported { get; set; }

        [JsonProperty("listProductExported")]
        public List<OutputProductDto> ListProductExported { get; set; }

        [JsonProperty("listProductBatches")]
        public List<ProductBatchInVentory> ListProductBatches { get; set; }

        [JsonProperty("listInventories")]
        public List<ProductBatchInVentory> ListInventories { get; set; }

    }
    public class ProductBatchInVentory
    {
        [JsonProperty("productBatchProductId")]
        public int Id { get; set; }

        [JsonProperty("productBatchId")]
        public int ProductBatchId { get; set; }

        [JsonProperty("dateExpiry")]
        public DateTime DateExpiry { get; set; }

        [JsonProperty("productQuantity")]
        public int ProductQuantity { get; set; }
    }
}
