﻿using shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Guid GetGuid();
        Product GetProductById(int id);
        void Add(Product product);
        void UpdateProduct(Product product);
    }
}
