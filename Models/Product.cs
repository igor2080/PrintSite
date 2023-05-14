namespace PrintSite.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
