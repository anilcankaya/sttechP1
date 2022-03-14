using introDotnetCore.Models;
using Microsoft.AspNetCore.Http;
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
        [HttpGet]
        public IActionResult UrunEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UrunEkle(Urun urun)
        {
            if (ModelState.IsValid)
            {
                //koleksiyona ekle....

                return View("Basarili");
            }
            return View();
        }


    }
}
