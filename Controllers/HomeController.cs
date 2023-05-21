﻿using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}