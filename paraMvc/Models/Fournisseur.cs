using paraMvc.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace paraMvc.Models
{
    public class Fournisseur:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Telephone  is required")]
        public string Telephone { get; set; }

       
    }
}
