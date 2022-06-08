using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Core.Models
{
    public class ProductBatchNoIdDto
    {
        [JsonProperty("productBatchName")]
        public string ProductBatchName { get; set; }

        [JsonProperty("inputInfoId")]

        public int InputInfoId { get; set; }
    }
}
