using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using shop.Models;
using shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private IProductService productService;
        private ICategoryService categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var products = productService.GetProducts();
            return View(products);
        }

        public IActionResult Create()
        {
           
            List<SelectListItem> selectLists = getCategoriesForSelect();

            ViewBag.SelectList = selectLists;

            return View();
        }

        private  List<SelectListItem> getCategoriesForSelect()
        {
            var categories =categoryService.GetCategories().ToList();
            List<SelectListItem> selectLists = new List<SelectListItem>();
            categories.ForEach(ct => selectLists.Add(new SelectListItem { Text = ct.Name, Value = ct.Id.ToString() }));
            return selectLists;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                productService.Add(product);
                return RedirectToAction(nameof(Index));
            }

            return View();


        }

        public IActionResult Update(int id)
        {
          
            var product = productService.GetProductById(id);
            ViewBag.SelectList = getCategoriesForSelect();
            return View(product);
        }



        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                productService.UpdateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
