using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop.Models;
using shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService productService;

        public ShoppingCartController(IProductService productService)
        {
            this.productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult AddProductToCart(int id)
        {
            //id'si eklenen ürünü, koleksiyona koleksiyonu da session'a ekle.
            Product product = productService.GetProductById(id);
            if (product!=null)
            {

            }
            return Json("Tamam");
        }
    }
}
