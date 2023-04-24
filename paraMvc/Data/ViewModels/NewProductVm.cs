using paraMvc.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace paraMvc.Data.ViewModels
{
    public class NewProductVm
    {
        public int Id { get; set; }

        [Display(Name = "Product name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Product description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in Dh")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Product poster URL")]
        [Required(ErrorMessage = "Product poster URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Movie category is required")]
        public Category ProductCategory { get; set; }
    }
}
