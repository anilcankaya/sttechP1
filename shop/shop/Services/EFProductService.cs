using shop.Data;
using shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Services
{
    public class EFProductService : IProductService
    {
        private ShopDbContext shopDbContext;

        public EFProductService(ShopDbContext shopDbContext)
        {
            this.shopDbContext = shopDbContext;
        }
        public Guid GetGuid()
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int id)
        {
            return shopDbContext.Products.Find(id);
        }

        public List<Product> GetProducts()
        {
            return shopDbContext.Products.ToList();
        }
    }
}
