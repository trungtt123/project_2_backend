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
        public DateTime OutputCreateTime { get; set; }
        public DateTime OutputUpdateTime { get; set; }
        public int PickerId { get; set; }
        public int SignatorId { get; set; }

        [ForeignKey("PickerId")]
        public virtual UserEntity Picker { get; set; }

        [ForeignKey("SignatorId")]
        public virtual UserEntity Signator { get; set; }

    }
}
