using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WareHouse.Core.Entities
{
    [Table("role")]
    public class RoleEntity
    {
        //public int UserId { get; set; }
        [Key]
        [Required]
        public int RoleId { get; set; }

        [StringLength(100)]
        [Required]
        public string RoleName { get; set; }


    }
}
