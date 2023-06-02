using Microsoft.AspNetCore.Identity;
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
            string admin_role_id = "5df4e6c4-8441-4851-952d-6f9bdd2b4026";
            string admin_id = "d408ddd2-3b69-412a-a8ca-da422c7ee890";
            var hasher = new PasswordHasher<IdentityUser>();
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = admin_role_id, Name = "admin", NormalizedName = "admin" },
                new IdentityRole { Id = new Guid().ToString(), Name = "regular", NormalizedName = "regular" });
            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = admin_id,
                    UserName = "admin",
                    NormalizedUserName = "admin",
                    Email = "admin@printsite.com",
                    NormalizedEmail = "admin@printsite.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "admin"),
                    SecurityStamp = string.Empty
                });
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = admin_role_id,
                    UserId = admin_id,
                });
            builder.Entity<Product>().HasKey(x => x.Id);
            builder.Entity<Product>().HasData(
                new Product { Id = ProductKey++, Description = "Business cards", Price = 10, Visible = true },
                new Product { Id = ProductKey++, Description = "Envelopes", Price = 15, Visible = true },
                new Product { Id = ProductKey++, Description = "Stickers", Price = 7.5f, Visible = true });
            base.OnModelCreating(builder);
        }
    }
}