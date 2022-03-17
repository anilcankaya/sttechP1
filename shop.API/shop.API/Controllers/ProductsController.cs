using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop.API.Dtos.Request;
using shop.API.Models;
using shop.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        //REST: Representational State Transfer 
        public ProductsController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = productService.GetProducts();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = productService.GetProductById(id);
            
            return Ok(product);
        }
        [HttpPost]
        public IActionResult AddProduct(AddProductRequest request)
        {
            //var product = new Product
            //{
            //    CategoryId = request.CategoryId,
            //    ImageUrl = request.ImageUrl,
            //    Discount = request.Discount,
            //    Name = request.Name,
            //    Price = request.Price,
            //    Stock = request.Stock
            //};

            if (ModelState.IsValid)
            {
                var product = mapper.Map<Product>(request);
                productService.Add(product);
                return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
            }
            return BadRequest(ModelState);          

        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            // TODO 1: Any ile ürün var mı diye kontrol et
            return Ok();            
        }
    }
}
