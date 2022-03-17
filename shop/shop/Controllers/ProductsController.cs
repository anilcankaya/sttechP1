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
        [HttpGet]
        public IActionResult Create()
        {

            List<SelectListItem> selectLists = getCategoriesForSelect();
            ViewBag.SelectList = selectLists;
            return View();
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

        private List<SelectListItem> getCategoriesForSelect()
        {
            var categories = categoryService.GetCategories().ToList();
            List<SelectListItem> selectLists = new List<SelectListItem>();
            categories.ForEach(ct => selectLists.Add(new SelectListItem { Text = ct.Name, Value = ct.Id.ToString() }));
            return selectLists;
        }



        public IActionResult Update(int id)
        {

            var product = productService.GetProductById(id);
            if (product != null)
            {
                ViewBag.SelectList = getCategoriesForSelect();
                return View(product);
            }

            ModelState.AddModelError("notFound", $"{id} id'li ürün bulunamadı");
            return View();


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

        public IActionResult Delete(int id)
        {
            var product = productService.GetProductById(id);
            return View(product);
        }

        [HttpPost()]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            return View();
        }
    }
}
