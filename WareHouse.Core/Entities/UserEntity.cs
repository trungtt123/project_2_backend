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

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string UserName { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Password { get; set; }
        
        [StringLength(100)]
        [Required]
        public string GivenName { get; set; }
        
        [StringLength(100)]
        [Required]
        public string SurName { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; } 
       

        [ForeignKey("RoleId")]
        public RoleEntity Role { get; set; }
        public ICollection<OutputInfoEntity> PickerOutputInfo { get; set; } = new List<OutputInfoEntity>();
        public ICollection<OutputInfoEntity> DeliverOutputInfo { get; set; } = new List<OutputInfoEntity>();
    }
}
