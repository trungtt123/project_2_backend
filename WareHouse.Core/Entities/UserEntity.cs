using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WareHouse.Core.Entities
{
    [Table("user")]
    public class UserEntity
    {
        [Key]
        [Required]
        public int UserId { get; set; }

        [StringLength(100)]
        [Required]
        public string UserName { get; set; }
        
        [StringLength(100)]
        [Required]
        public string PassWord { get; set; }
        
        [StringLength(100)]
        [Required]
        public string GivenName { get; set; }
        
        [StringLength(100)]
        [Required]
        public string SurName { get; set; }
        public int RoleId { get; set; }
        
        [ForeignKey("RoleId")]
        public RoleEntity Role { get; set; }
        public ICollection<OutputInfoEntity> PickerOutputInfo { get; set; } = new List<OutputInfoEntity>();
        public ICollection<OutputInfoEntity> DeliverOutputInfo { get; set; } = new List<OutputInfoEntity>();
    }
}
