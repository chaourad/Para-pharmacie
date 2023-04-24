using System.ComponentModel.DataAnnotations;

namespace paraMvc.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Product Product { get; set; }
        public int quantite { get; set; }


        public string ShoppingCartId { get; set; }
    }
}
