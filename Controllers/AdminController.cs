using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using PrintSite.Data;
using PrintSite.Models;

namespace PrintSite.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly ApplicationDbContext _context;

        public AdminController(IStringLocalizer<HomeController> localizer, ApplicationDbContext context)
        {
            _localizer = localizer;
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult ToggleProductVisibility(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.Visible = !product.Visible;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct(int id)
        {
            Product? product = _context.Products.SingleOrDefault(x => x.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View(null);
        }

        [HttpPost]
        public IActionResult CreateProduct(float price, string description)
        {
            List<string> errors = new List<string>();
            if (price < 0.1)
                errors.Add("badprice");
            if (description == null || description.Length < 1)
                errors.Add("baddescription");
            if (errors.Count > 0)
            {
                return View("CreateProduct", errors);
            }
            Product product = new Product() { Description = description, Price = price };
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
