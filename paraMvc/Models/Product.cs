using System.ComponentModel.DataAnnotations;
using paraMvc.Data.Base;
using paraMvc.Data.Enums;

namespace paraMvc.Models
{
    public class Product : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Name of product")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Display(Name = "Image")]
        public string ImageURL { get; set; }

        public Category ProductCategory { get; set; }

        public List<DemmandeItems> DemmandeItems { get; set; }
        

    }
}
