using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WareHouse.Core.Entities
{
    [Table("productbatch")]
    public class ProductBatchEntity
    {
        [Key]
        public int ProductBatchId { get; set; }
        public string ProductBatchName { get; set; }
        public int ProductId { get; set; } 

        [ForeignKey("ProductId")]
        public ProductEntity Product { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime DateExpiry { get; set; }

        public int? InputInfoId { get; set; }

        [ForeignKey("InputInfoId")]
        public InputInfoEntity? InputInfo { get; set; }

    }
}
