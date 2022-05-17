using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Core.Models
{
    public class ProductNoIdDto
    { 
        public string ProductName { get; set; }
        public string ProductOrgin { get; set; }
        public string ProductSuplier { get; set; }
        public int ProductTypeId { get; set; }
        public string ProductUnit { get; set; }
    }
}
