using Microsoft.AspNetCore.Identity;

namespace PrintSite.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public IdentityUser CartUser { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
