using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Core.Models
{
    public class EmailFormDto
    {
        public string emailFrom { get; set; }
        public string emailTo { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
    }
}
