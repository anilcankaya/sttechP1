using shop.API.Dtos.Request;
using shop.API.Dtos.Response;
using shop.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.API.Services
{
    public interface IProductService
    {
        List<ProductListResponse> GetProducts();       
        ProductListResponse GetProductById(int id);
        int Add(AddProductRequest request);
        void UpdateProduct(UpdateProductRequest product);

        bool IsProductExist(int id);

    }
}
