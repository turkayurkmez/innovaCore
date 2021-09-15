using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Models
{
    public class ShoppingCard
    {
        public List<ProductInCard> Card { get; set; } = new List<ProductInCard>();

        public void AddProductToCard(Product product, int quantity)
        {
            var existingProduct = Card.FirstOrDefault(c => c.Product.Id == product.Id);
            if (existingProduct == null)
            {
                Card.Add(new ProductInCard { Product = product, Quantity = quantity });
            }
            else
            {
                existingProduct.Quantity += quantity;
            }
        }

        public decimal TotalPrice
        {
            get => Card.Sum(c => c.Product.Price * (decimal)(1 - c.Product.Discount)* c.Quantity);
        }

        public void ClearCard()
        {
            Card.Clear();
        }

        public void RemoveFromCard(Product product)
        {
            Card.RemoveAll(p => p.Product.Id == product.Id);
        }
    }
}
