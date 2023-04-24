using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using paraMvc.Data.Base;

namespace paraMvc.Models
{
    public class OrderItems : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public int qte { get; set; }
        public double Price { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Orders Orders { get; set; }
    }
}
