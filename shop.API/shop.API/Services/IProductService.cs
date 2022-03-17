using shop.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.API.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();       
        Product GetProductById(int id);
        void Add(Product product);
        void UpdateProduct(Product product);
    }
}
