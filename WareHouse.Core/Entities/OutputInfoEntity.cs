using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WareHouse.Core.Entities
{
    [Table("outputinfo")]
    public class OutputInfoEntity
    {
        [Key]
        public int OutputInfoId { get; set; }
        public string OutputInfoName { get; set; }
        //public int ProductId { get; set; }

        //[ForeignKey("ProductId")]
        //public ProductEntity Product { get; set; }
        public int ProductQuantity { get; set; }
        public string OutputTime { get; set; }
        public int PickerUserId { get; set; }
        public int DeliverUserId { get; set; }

        [ForeignKey("PickerUserId")]
        public virtual UserEntity PickerUser { get; set; }

        

        [ForeignKey("DeliverUserId")]
        public virtual UserEntity DeliverUser { get; set; }

    }
}
