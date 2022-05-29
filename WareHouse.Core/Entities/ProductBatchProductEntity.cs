using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WareHouse.Core.Entities
{
    [Table("productbatch_product")]
    public class ProductBatchProductEntity
    {

        public int ProductBatchId { get; set; }

        [ForeignKey("ProductBatchId")]
        public ProductBatchEntity ProductBatch { get; set; }
        public int ProductId { get; set; } 

        [ForeignKey("ProductId")]
        public ProductEntity Product { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime DateExpiry { get; set; }


    }
}
