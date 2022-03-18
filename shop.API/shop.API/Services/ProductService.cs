using AutoMapper;
using Microsoft.EntityFrameworkCore;
using shop.API.Data;
using shop.API.Dtos.Request;
using shop.API.Dtos.Response;
using shop.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.API.Services
{
    public class EFProductService : IProductService
    {
        private ShopdbContext shopDbContext;
        private readonly IMapper mapper;

        public EFProductService(ShopdbContext shopDbContext, IMapper mapper)
        {
            this.shopDbContext = shopDbContext;
            this.mapper = mapper;
        }

        public int Add(AddProductRequest request)
        {
            var product = mapper.Map<Product>(request);
            shopDbContext.Products.Add(product);
            shopDbContext.SaveChanges();
            return product.Id;
        }

       

        public ProductListResponse GetProductById(int id)
        {

            var product = shopDbContext.Products.Find(id);
            var response = mapper.Map<ProductListResponse>(product);
            return response;
        }

        public List<ProductListResponse> GetProducts()
        {
            var products = shopDbContext.Products.ToList();
            var responseList = mapper.Map<List<ProductListResponse>>(products);
            return responseList;
        }

        public void UpdateProduct(UpdateProductRequest request)
        {
            //shopDbContext.Entry<Product>(product).State = EntityState.Modified;
            var product = mapper.Map<Product>(request);
            shopDbContext.Products.Update(product);
            shopDbContext.SaveChanges();
        }

        public bool IsProductExist(int id)
        {
            return shopDbContext.Products.Any(p => p.Id == id);
        }

        public void Delete(int id)
        {
            var product = shopDbContext.Products.FirstOrDefault(p => p.Id == id);
            shopDbContext.Products.Remove(product);
            shopDbContext.SaveChanges();
        }
    }
}
