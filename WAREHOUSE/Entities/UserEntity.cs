using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WAREHOUSE.Entities
{
    [Table("user")]
    public class UserEntity
    {
        //public int UserId { get; set; }
        [Key]
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
        
        [StringLength(100)]
        [Required]
        public string Role { get; set; }

    }
}
