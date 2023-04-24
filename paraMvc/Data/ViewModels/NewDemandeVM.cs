using paraMvc.Models;

namespace paraMvc.Data.ViewModels
{
    public class NewDemandeVM
    {
        public NewDemandeVM()
        {
            Fournisseurs = new List<Fournisseur>();
            DemmandeItemss = new List<DemmandeItems>();
        }
        public List<Fournisseur> Fournisseurs { get; set; }
        public List<DemmandeItems> DemmandeItemss { get; set; }
    }
}
