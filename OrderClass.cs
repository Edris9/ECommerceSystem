using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceSystem
{
    internal class OrderClass
    {
        private string OrderID { get; set; }
        private string CustomerID { get; set; }
        private List<Product> OrderedProducts { get; set; }
        private Dictionary<int, int> ProductQuantities { get; set; } // ProductID → Quantity
        private decimal TotalAmount { get; set; }
        private string OrderStatus { get; set; }
        private DateTime OrderDate { get; set; }

        // Konstruktor
        public OrderClass()
        {
            OrderedProducts = new List<Product>();
            ProductQuantities = new Dictionary<int, int>();
        }

        public void CreateOrder(string customerId, List<Product> products, Dictionary<int, int> quantities)
        {
            OrderID = Guid.NewGuid().ToString();
            CustomerID = customerId;
            OrderedProducts = products;
            ProductQuantities = quantities;

            // Beräkna totalpris med quantities
            TotalAmount = 0;
            foreach (var product in products)
            {
                TotalAmount += product.Price * ProductQuantities[product.ProductId];
            }

            OrderStatus = "Pending";
            OrderDate = DateTime.Now;
            Console.WriteLine($"Order {OrderID} created for Customer {CustomerID} with total amount {TotalAmount:C}.");
        }

        public void AddProduct(Product product, int quantity)
        {
            OrderedProducts.Add(product);
            ProductQuantities[product.ProductId] = quantity;
            CalculateTotal();
            Console.WriteLine($"{product.ProductName} added to order {OrderID}.");
        }

        public void RemoveProduct(Product product)
        {
            OrderedProducts.Remove(product);
            ProductQuantities.Remove(product.ProductId);
            CalculateTotal();
            Console.WriteLine($"{product.ProductName} removed from order {OrderID}.");
        }

        public void CalculateTotal()
        {
            TotalAmount = 0;
            foreach (var product in OrderedProducts)
            {
                TotalAmount += product.Price * ProductQuantities[product.ProductId];
            }
            Console.WriteLine($"Total amount for order {OrderID} recalculated: {TotalAmount:C}.");
        }

        public void UpdateOrderStatus(string newStatus)
        {
            OrderStatus = newStatus;
            Console.WriteLine($"Order {OrderID} status updated to {OrderStatus}.");
        }

        public void CancelOrder()
        {
            OrderStatus = "Cancelled";
            Console.WriteLine($"Order {OrderID} has been cancelled.");
        }

        public void ProcessPayment()
        {
            Console.WriteLine($"Processing payment of {TotalAmount:C} for order {OrderID}...");
            Console.WriteLine("Payment successful!");
            UpdateOrderStatus("Paid");
        }

        public void GetOrderDetails()
        {
            Console.WriteLine($"Order ID: {OrderID}");
            Console.WriteLine($"Customer ID: {CustomerID}");
            Console.WriteLine($"Order Date: {OrderDate}");
            Console.WriteLine($"Order Status: {OrderStatus}");
            Console.WriteLine("Ordered Products:");
            foreach (var product in OrderedProducts)
            {
                Console.WriteLine($"- {product.ProductName} (x{ProductQuantities[product.ProductId]}): {product.Price:C} each");
            }
            Console.WriteLine($"Total Amount: {TotalAmount:C}");
        }
    }
}