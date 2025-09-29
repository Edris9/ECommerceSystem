using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem
{
    internal class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }

        public void UpdateStock(int quantity)
        {
            StockQuantity += quantity;
            Console.WriteLine($"Stock updated. New quantity: {StockQuantity}");
        }

        public bool CheckAvailability()
        {
            return StockQuantity > 0;
        }

        public void UpdatePrice(decimal newPrice)
        {
            Price = newPrice;
            Console.WriteLine($"Price updated to: {Price:C}");
        }

    }
}
