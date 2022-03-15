using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Models
{
    public class ShoppingCartCollection
    {
        //koleksiyon public bir property çünkü serileşmesini istiyoruz:
        public List<ProductInCart> productsInCart { get; set; } = new List<ProductInCart>();
        public double GetTotalPrice()
        {
            return productsInCart.Sum(p => p.Quantity * (p.Product.Price.Value * (1 - p.Product.Discount.Value)));
        }

        public void RemoveProductInCart(int id)
        {
            productsInCart.RemoveAll(p => p.Product.Id == id);
        }
        public void ClearCart()
        {
            productsInCart.Clear();
        }

        public void AddProduct(Product product, int quantity)
        {
            var exist = productsInCart.FirstOrDefault(p => p.Product.Id == product.Id);
            if (exist == null)
            {
                productsInCart.Add(new ProductInCart { Product = product, Quantity = quantity });
            }
            else
            {
                exist.Quantity += quantity;
            }
        }

    }

    public class ProductInCart
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}

