using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using paraMvc.Data.Base;

namespace paraMvc.Models
{
    public class DemmandeItems : IEntityBase
    {

        [Key]
        public int Id { get; set; }

        public int qte { get; set; }
        public double Price { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int DemmandeId { get; set; }
        [ForeignKey("DemmandeId")]
        public Demmande Demmande { get; set; }
    }
}
