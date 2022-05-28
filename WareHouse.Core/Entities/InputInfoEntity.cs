using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WareHouse.Core.Entities
{
    [Table("inputinfo")]
    public class InputInfoEntity
    {
        [Key]
        public int InputInfoId { get; set; }
        public string InputInfoName { get; set; }
        //public int ProductBatchId { get; set; }

        //[ForeignKey("ProductBatchId")]
        //public ProductBatchEntity ProductBatch { get; set; }
        public DateTime InputCreateTime { get; set; }
        public DateTime InputUpdateTime { get; set; }
        public string Shipper { get; set; }
        public int ReceiverUserId { get; set; }

        [ForeignKey("ReceiverUserId")]
        public UserEntity ReceiverUser { get; set; }
    }
}
