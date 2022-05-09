using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WareHouse.Core.Entities
{
    [Table("producttype")]
    public class ProductTypeEntity
    {
        //public int UserId { get; set; }
        [Key]
        public int ProductTypeId { get; set; }
        public string ProductTypeName{ get; set; }

      
    }
}
