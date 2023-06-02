using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using PrintSite.Data;

namespace PrintSite.Controllers
{
    [Authorize(Roles ="admin")]
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
    }
}
