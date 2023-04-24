using Microsoft.AspNetCore.Identity;

namespace PrintSite.Models
{
    public class Order
    {
        public int Id { get; set; }
        public IdentityUser User { get; set; }
        public float Price { get; set; }
        public virtual OrderStatus Status { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
