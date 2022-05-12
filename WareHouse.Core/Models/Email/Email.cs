using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Core.Models
{
    public class EmailForm
    {
        public string EmailFrom { get; set; }
        public string EmailTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
