using paraMvc.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace paraMvc.Models
{
    public class Orders : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public DateTime date { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
        public List<OrderItems> OrderItems { get; set; }
    }
}
