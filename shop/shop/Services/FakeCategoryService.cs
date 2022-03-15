using shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Services
{
    public class FakeCategoryService : ICategoryService
    {
        private List<Category> categories = null;
        public FakeCategoryService()
        {
            categories = new List<Category>
            {
                new Category{ Id=1, Name="Laptop"},
                new Category{ Id=2, Name="Tablet"},
                new Category{ Id=3, Name="Telefon"},


            };
        }
        public IList<Category> GetCategories()
        {
            return categories;
        }
    }
}
