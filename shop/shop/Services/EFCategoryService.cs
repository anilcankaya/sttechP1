using shop.Data;
using shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Services
{
    public class EFCategoryService : ICategoryService
    {
        private ShopDbContext shopDbContext;

        public EFCategoryService(ShopDbContext shopDbContext)
        {
            this.shopDbContext = shopDbContext;
        }
        public IList<Category> GetCategories()
        {
            return shopDbContext.Categories.ToList();
        }
    }
}
