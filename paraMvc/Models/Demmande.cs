using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using paraMvc.Data.Base;

namespace paraMvc.Models
{
    public class Demmande : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public DateTime date { get; set; }
        public int FournisseurId { get; set; }
        [ForeignKey(nameof(FournisseurId))]
        public Fournisseur Fournisseur { get; set; }
        public List<DemmandeItems> DemmandeItems { get; set; }


        
      
    }
}
