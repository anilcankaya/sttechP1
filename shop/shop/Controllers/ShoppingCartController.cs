using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop.Extensions;
using shop.Models;
using shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
            var collection = getCollectionFromSession();
            return View(collection);
        }

        public IActionResult AddProductToCart(int id)
        {
            //id'si eklenen ürünü, koleksiyona koleksiyonu da session'a ekle.
            Product product = productService.GetProductById(id);
            if (product != null)
            {
                ShoppingCartCollection cartCollection = getCollectionFromSession();
                cartCollection.AddProduct(product, 1);
                saveToSession(cartCollection);
            }
            return Json(product.Name + " sepete eklendi");
        }

        private void saveToSession(ShoppingCartCollection cartCollection)
        {
            //string serialized =  JsonSerializer.Serialize(cartCollection);
            // HttpContext.Session.SetString("cart", serialized);
            HttpContext.Session.SetJson("cart", cartCollection);

        }

        private ShoppingCartCollection getCollectionFromSession()
        {
            //ShoppingCartCollection shoppingCart = null;
            //if (HttpContext.Session.GetString("cart")==null)
            //{
            //    shoppingCart = new ShoppingCartCollection();
            //    HttpContext.Session.SetString("cart", JsonSerializer.Serialize(shoppingCart)); 
            //}
            //string serialized = HttpContext.Session.GetString("cart");
            //var shopping = JsonSerializer.Deserialize<ShoppingCartCollection>(serialized);
            //return shopping;

            //Random random = new Random();
            //string test =  random.NextWord("test", "deneme", "softtech");

            ShoppingCartCollection shoppingCartCollection = HttpContext.Session.GetJson<ShoppingCartCollection>("cart") ?? 
                                                            new ShoppingCartCollection();
            return shoppingCartCollection;

        }
    }
}
