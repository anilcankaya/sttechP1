using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using shop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product { Id=1, Name="Dell XPS 15", Price=35000, Discount=0.15, ImageUrl="https://productimages.hepsiburada.net/s/179/222-222/110000143663463.jpg"},

                new Product { Id=2, Name="Dell XPS 13", Price=25000, Discount=0.10, ImageUrl="https://productimages.hepsiburada.net/s/179/222-222/110000143663463.jpg"},

                new Product { Id=3, Name="Huawei", Price=8000, Discount=0.15, ImageUrl="https://productimages.hepsiburada.net/s/179/222-222/110000143663463.jpg"},

                new Product { Id=4, Name="Mac Book Pro", Price=52000, Discount=0.10, ImageUrl="https://productimages.hepsiburada.net/s/179/222-222/110000143663463.jpg"}

            };

            return View(products);
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
