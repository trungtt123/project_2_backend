using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WareHouse.Core.Entities
{
    [Table("inputinfo")]
    public class InputInfoEntity
    {
        //public int UserId { get; set; }
        public int InputInfoId { get; set; }
        public string InputInfoName { get; set; }
        public int ProductBatchId { get; set; }

        [ForeignKey("ProductBatchId")]
        public ProductBatchEntity ProductBatch { get; set; }
        public string InputTime { get; set; }
        public string Shipper { get; set; }
        public int ReceiverUserId { get; set; }

        [ForeignKey("ReceiverUserId")]
        public UserEntity ReceiverUser { get; set; }
    }
}
