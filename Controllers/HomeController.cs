using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using PrintSite.Data;
using PrintSite.Models;
using System.Diagnostics;

namespace PrintSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly ApplicationDbContext _context;

        public HomeController(IStringLocalizer<HomeController> localizer, ApplicationDbContext context)
        {
            _localizer = localizer;
            _context = context;
        }

        public IActionResult Index()
        {

            return View(_context.Products.ToList());
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult SetLanguage(string language)
        {
            try
            {
                var culture = new RequestCulture(language);
                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(culture)
                    );
            }
            catch { }
            
            return Redirect(Request.Headers["referer"]);
        }

    }
}