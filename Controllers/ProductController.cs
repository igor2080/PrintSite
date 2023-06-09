﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using PrintSite.Data;
using PrintSite.Models;
using System.Security.Claims;

namespace PrintSite.Controllers
{
    public class ProductController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ProductController(IStringLocalizer<HomeController> localizer, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _localizer = localizer;
            _context = context;
            _userManager = userManager;
        }

        [Route("Product/{id}")]
        public IActionResult Index(int id)
        {
            var result = _context.Products.Include(x => x.ShoppingCarts).ThenInclude(x => x.CartUser).Where(x => x.Id == id).SingleOrDefault();
            if (result.Visible)
                return View(result);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Route("Product/AddToCart/{id}")]
        public IActionResult AddToCart(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return Redirect("~/Identity/Account/Login");//user not logged in, send to login?
            else
            {
                var product = _context.Products.SingleOrDefault(x => x.Id == id);
                if (product == null) return Redirect("~/");
                var userName = User.FindFirstValue(ClaimTypes.Name);
                var cart = _context.ShoppingCarts.Include(x => x.Products).Where(x => x.CartUser.UserName == User.Identity.Name).SingleOrDefault();
                if (cart == null)
                {
                    IdentityUser user = _userManager.GetUserAsync(User).Result;
                    _context.ShoppingCarts.Add(new ShoppingCart
                    {
                        CartUser = user,
                        Products = new List<Product>() { product }
                    });

                    _context.SaveChanges();
                }
                else
                {
                    cart.Products.Add(product);
                    _context.SaveChanges();
                }
            }

            return Redirect("~/Product/" + id);
        }
    }
}
