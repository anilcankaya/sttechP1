using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace introDotnetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string ad = "Türkay Ürkmez";
            ViewBag.Ad = ad;
            ViewBag.Saat = DateTime.Now.Hour;
            return View();
        }

        public IActionResult UrunEkle()
        {
            return View();
        }
    }
}
