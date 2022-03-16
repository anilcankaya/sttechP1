using Microsoft.AspNetCore.Mvc;
using shop.Extensions;
using shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.ViewComponents
{
    public class CartDetailViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var collection = HttpContext.Session.GetJson<ShoppingCartCollection>("cart");
            //int totalProductsCount = collection == null ? 0 : collection.productsInCart.Sum(p => p.Quantity);
            return View(collection);
        }
    }
}
