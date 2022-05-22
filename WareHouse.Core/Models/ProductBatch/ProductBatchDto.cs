using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Core.Models
{
    public class ProductBatchDto
    {
        public int productBatchId { get; set; }
        public string productBatchName { get; set; }
        public int productId { get; set; }
        public int productQuantity { get; set; }
        public string dateExpiry { get; set; }
    }
}
