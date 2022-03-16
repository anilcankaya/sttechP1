using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Areas.StoreArea.Controllers
{
    [Area("StoreArea")]
    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
