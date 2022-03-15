using shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Services
{
    public class FakeProductServices : IProductService
    {
        private List<Product> products = new List<Product>();
        public FakeProductServices()
        {
            products = new List<Product>
            {
                new Product { Id=1, Name="Dell XPS 15", Price=35000, Discount=0.15, ImageUrl="https://productimages.hepsiburada.net/s/179/222-222/110000143663463.jpg"},

                new Product { Id=2, Name="Dell XPS 13", Price=25000, Discount=0.10, ImageUrl="https://productimages.hepsiburada.net/s/179/222-222/110000143663463.jpg"},

                new Product { Id=3, Name="Huawei", Price=8000, Discount=0.15, ImageUrl="https://productimages.hepsiburada.net/s/179/222-222/110000143663463.jpg"},

                new Product { Id=4, Name="Mac Book Pro", Price=52000, Discount=0.10, ImageUrl="https://productimages.hepsiburada.net/s/179/222-222/110000143663463.jpg"},

                 new Product { Id=5, Name="Dell XPS 15", Price=35000, Discount=0.15, ImageUrl="https://productimages.hepsiburada.net/s/179/222-222/110000143663463.jpg"},

                new Product { Id=6, Name="Dell XPS 13", Price=25000, Discount=0.10, ImageUrl="https://productimages.hepsiburada.net/s/179/222-222/110000143663463.jpg"},

                new Product { Id=7, Name="Huawei", Price=8000, Discount=0.15, ImageUrl="https://productimages.hepsiburada.net/s/179/222-222/110000143663463.jpg"},

                new Product { Id=8, Name="Mac Book Pro", Price=52000, Discount=0.10, ImageUrl="https://productimages.hepsiburada.net/s/179/222-222/110000143663463.jpg"},
                 new Product { Id=9, Name="Dell XPS 15", Price=35000, Discount=0.15, ImageUrl="https://productimages.hepsiburada.net/s/179/222-222/110000143663463.jpg"},

                new Product { Id=21, Name="Dell XPS 13", Price=25000, Discount=0.10, ImageUrl="https://productimages.hepsiburada.net/s/179/222-222/110000143663463.jpg"},

                new Product { Id=31, Name="Huawei", Price=8000, Discount=0.15, ImageUrl="https://productimages.hepsiburada.net/s/179/222-222/110000143663463.jpg"},

                new Product { Id=41, Name="Mac Book Pro", Price=52000, Discount=0.10, ImageUrl="https://productimages.hepsiburada.net/s/179/222-222/110000143663463.jpg"},

                 new Product { Id=51, Name="Dell XPS 15", Price=35000, Discount=0.15, ImageUrl="https://productimages.hepsiburada.net/s/179/222-222/110000143663463.jpg"},

                new Product { Id=6, Name="Dell XPS 13", Price=25000, Discount=0.10, ImageUrl="https://productimages.hepsiburada.net/s/179/222-222/110000143663463.jpg"},

              

            };

            guid = Guid.NewGuid();
        }
        private Guid guid;
        public Guid GetGuid()
        {
            return guid;
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public Product GetProductById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }
    }
}
