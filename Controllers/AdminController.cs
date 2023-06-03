using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Orders()
        {
            var orders = _context.Orders.Include(x => x.Products).Include(x => x.Status).ToList();
            return View(orders);
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

        public IActionResult OrderEdit(int id)
        {
            var order = _context.Orders.Include(x => x.Products).Include(x => x.Status).SingleOrDefault(x => x.Id == id);
            return View(order);
        }
        [HttpPost]
        public IActionResult OrderEdit(Order order)
        {
            var existingOrder = _context.Orders.SingleOrDefault(x => x.Id == order.Id);
            if (existingOrder != null)
            {
                existingOrder.Price = order.Price;
                existingOrder.Status = order.Status;
                _context.SaveChanges();
            }
            return RedirectToAction("Orders");
        }
        public IActionResult OrderDelete(int id)
        {
            var order = _context.Orders.SingleOrDefault(x => x.Id == id);
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return RedirectToAction("Orders");
        }

        [HttpGet]
        public IActionResult Manage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Manage(IFormFile logo)
        {
            if (logo != null)
            {
                string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", "sitelogo.png");
                using (var stream = new FileStream(SavePath, FileMode.OpenOrCreate))
                {
                    logo.CopyTo(stream);
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult ResetLogo()
        {
            string originalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", "sitelogo - backup.png");
            string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", "sitelogo.png");
            using (var original = new FileStream(originalPath, FileMode.Open))
            {
                using (var stream = new FileStream(SavePath, FileMode.OpenOrCreate))
                {
                    original.CopyTo(stream);
                }
            }
            return RedirectToAction("Manage");
        }
    }
}
