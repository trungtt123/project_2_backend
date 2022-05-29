using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WareHouse.Core.Entities
{
    [Table("output_product")]
    public class OutputProductEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public ProductEntity Product { get; set; }
        public int OutputInfoId { get; set; }

        [ForeignKey("OutputInfoId")]
        public OutputInfoEntity OutputInfo { get; set; }

        public int ProductBatchId { get; set; }

        [ForeignKey("ProductBatchId")]
        public ProductBatchEntity ProductBatch { get; set; }
        public int ProductQuantity { get; set; }


    }
}
