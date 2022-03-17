using Microsoft.EntityFrameworkCore;
using shop.API.Data;
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

        public EFProductService(ShopdbContext shopDbContext)
        {
            this.shopDbContext = shopDbContext;
        }

        public void Add(Product product)
        {
            shopDbContext.Products.Add(product);
            shopDbContext.SaveChanges();

        }

       

        public Product GetProductById(int id)
        {
            return shopDbContext.Products.Find(id);
        }

        public List<Product> GetProducts()
        {
            return shopDbContext.Products.ToList();
        }

        public void UpdateProduct(Product product)
        {
            //shopDbContext.Entry<Product>(product).State = EntityState.Modified;
            shopDbContext.Products.Update(product);
            shopDbContext.SaveChanges();
        }
    }
}
