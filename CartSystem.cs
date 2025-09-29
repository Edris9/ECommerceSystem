using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceSystem
{
    internal class CartSystem
    {
        public List<Product> CartItems { get; private set; }
        public Dictionary<int, int> ProductQuantities { get; private set; } // ProductID → Quantity
        public string CustomerID { get; set; }
        public decimal TotalPrice { get; private set; }

        // Konstruktor
        public CartSystem(string customerID)
        {
            CustomerID = customerID;
            CartItems = new List<Product>();
            ProductQuantities = new Dictionary<int, int>();
            TotalPrice = 0;
        }

        // Lägg till produkt
        public void AddProduct(Product product, int quantity)
        {
            if (product.CheckAvailability() && product.StockQuantity >= quantity)
            {
                CartItems.Add(product);
                ProductQuantities[product.ProductId] = quantity;
                CalculateTotal();
                Console.WriteLine($"{product.ProductName} added to cart!");
            }
            else
            {
                Console.WriteLine("Product not available!");
            }
        }

        // Ta bort produkt
        public void RemoveProduct(int productId)
        {
            var product = CartItems.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                CartItems.Remove(product);
                ProductQuantities.Remove(productId);
                CalculateTotal();
                Console.WriteLine($"{product.ProductName} removed from cart!");
            }
        }

        // Uppdatera quantity
        public void UpdateQuantity(int productId, int newQuantity)
        {
            if (ProductQuantities.ContainsKey(productId))
            {
                ProductQuantities[productId] = newQuantity;
                CalculateTotal();
                Console.WriteLine("Quantity updated!");
            }
        }

        // Beräkna totalpris
        private void CalculateTotal()
        {
            TotalPrice = 0;
            foreach (var product in CartItems)
            {
                TotalPrice += product.Price * ProductQuantities[product.ProductId];
            }
        }

        // Töm kundvagn
        public void ClearCart()
        {
            CartItems.Clear();
            ProductQuantities.Clear();
            TotalPrice = 0;
            Console.WriteLine("Cart cleared!");
        }
    }
}