using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WareHouse.Core.Models
{
    public class InputInfoProductBatchNoIdDto
    {
        public int InputInfoId { get; set; }
        public int ProductBatchId { get; set; }
    }
}
