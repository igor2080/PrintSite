using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using PrintSite.Data;
using PrintSite.Models;

namespace PrintSite.Controllers
{
    [Authorize]
    public class ShoppingController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ShoppingController(IStringLocalizer<HomeController> localizer, UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _localizer = localizer;
            _userManager = userManager;
            _context = context;
        }

        public int GetCartItemCount()
        {
            var cart = _context.ShoppingCarts.SingleOrDefault(x => x.CartUser.UserName == User.Identity.Name);
            if (cart is null)
            {
                return -1;
            }
            else return cart.Products.Count;
        }
        public IActionResult Cart()
        {
            var cart = _context.ShoppingCarts.Include(x => x.Products).SingleOrDefault(x => x.CartUser.UserName == User.Identity.Name);
            if (cart is null || cart.Products.Count < 1)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(cart.Products);
        }

        public IActionResult ShoppingItemDelete(int id)
        {
            var cart = _context.ShoppingCarts.Include(x => x.Products).SingleOrDefault(x => x.CartUser.UserName == User.Identity.Name);
            if (cart is not null)
            {
                Product? product = cart.Products.SingleOrDefault(x => x.Id == id);
                if (product is not null)
                {
                    cart.Products.Remove(product);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Cart", "Shopping");
        }

        [HttpPost]
        public IActionResult AddOrder()
        {
            ShoppingCart cart = _context.ShoppingCarts.Include(x => x.Products).Include(x=>x.CartUser).SingleOrDefault(x => x.CartUser.UserName == User.Identity.Name);
            if (cart == null)
            {
                return RedirectToAction("Cart");
            }
            else
            {
                Order order = new Order()
                {
                    Price = cart.Products.Sum(x => x.Price),
                    Products = cart.Products,
                    Status = new OrderStatus() { Status = "Sent" },
                    User = cart.CartUser

                };
                _context.Orders.Add(order);
                _context.ShoppingCarts.Remove(cart);
                _context.SaveChanges();
            }
            return RedirectToAction("OrderAdded");
        }

        public IActionResult OrderAdded()
        {
            return View();
        }
    }
}
