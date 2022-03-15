using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using shop.Models;
using shop.Services;
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
        private readonly IProductService productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            this.productService = productService;
        }
      

        [HttpGet]
        public IActionResult Index(int page=1)
        {
            //var service = new FakeProductServices();
            //ViewBag.Value = productService.GetGuid().ToString();
            var products = productService.GetProducts();
            
            /*
             * page 1 ise 0 eleman atla 4 eleman getir
             *      2     4             4
             *      3     8             4
             *      4     12            4
             */        

            var itemsPerPage = 4;
            ViewBag.TotalPages = Math.Ceiling((decimal)products.Count / itemsPerPage);
            ViewBag.Page = page;

            products = products.OrderBy(x => x.Id)
                               .Skip((page - 1) * itemsPerPage)
                               .Take(itemsPerPage)
                               .ToList();


          
            return View(products);
        }
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
