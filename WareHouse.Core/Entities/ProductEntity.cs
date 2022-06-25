using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WareHouse.Core.Entities
{
    [Table("product")]
    public class ProductEntity
    {
        //public int UserId { get; set; }
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductOrigin { get; set; }
        public string ProductSuplier { get; set; }
        public int ProductTypeId { get; set; }

        [ForeignKey("ProductTypeId")]
        public ProductTypeEntity ProductType { get; set; }
        public string ProductUnit { get; set; }
    }
}
