using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrintSite.Models;

namespace PrintSite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            int ProductKey = 1;
            builder.Entity<Product>().HasKey(x => x.Id);
            builder.Entity<Product>().HasData(
                new Product { Id = ProductKey++, Description = "Business cards", Price = 10 },
                new Product { Id = ProductKey++, Description = "Envelopes", Price = 15 },
                new Product { Id = ProductKey++, Description = "Stickers", Price = 7.5f });

            base.OnModelCreating(builder);
        }

    }
}