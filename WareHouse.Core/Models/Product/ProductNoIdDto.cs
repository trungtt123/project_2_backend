using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Core.Models
{
    public class ProductNoIdDto
    { 
        public string productName { get; set; }
        public string productOrgin { get; set; }
        public string productSuplier { get; set; }
        public int productTypeId { get; set; }
        public string productUnit { get; set; }
    }
}
