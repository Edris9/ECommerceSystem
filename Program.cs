namespace ECommerceSystem
{
    internal class Program
    {
        static List<Customer> customers = new List<Customer>();
        static List<Admin> admins = new List<Admin>();
        static List<Product> products = new List<Product>();

        static void Main(string[] args)
        {
            products.Add(new Product { ProductId = 1, ProductName = "Laptop", Price = 999.99m, StockQuantity = 10, Brand = "Dell", Category = "Electronics" });
            products.Add(new Product { ProductId = 2, ProductName = "Mouse", Price = 29.99m, StockQuantity = 50, Brand = "Logitech", Category = "Accessories" });
            products.Add(new Product { ProductId = 3, ProductName = "Keyboard", Price = 79.99m, StockQuantity = 30, Brand = "Razer", Category = "Accessories" });


            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== E-Commerce System ===");
                Console.WriteLine("1. Customer Login");
                Console.WriteLine("2. Admin Login");
                Console.WriteLine("3. Create Account");
                Console.WriteLine("4. Exit");
                Console.Write("Choose option: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    CustomerLogin();
                }
                else if (choice == 2)
                {
                    AdminLogin();
                }
                else if (choice == 3)
                {
                    CreateAccount();
                }
                else if (choice == 4)
                {
                    running = false;
                    Console.WriteLine("Goodbye!");
                }
                else
                {
                    Console.WriteLine("Invalid option!");
                }
            }
        }




        static void CustomerLogin()
        {
            Console.WriteLine("\nCustomer Login");
            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            foreach (var customer in customers)
            {
                if (customer.Login(email, password))
                {
                    Console.WriteLine($"Welcome back, {customer.Name}!");
                    CustomerMenu(customer);
                    return;
                }
            }
            Console.WriteLine("Invalid email or password.");
        }


        static void CustomerMenu(Customer customer)
        {
            bool inMenu = true;
            while (inMenu)
            {
                Console.WriteLine("\n=== Customer Menu ===");
                Console.WriteLine("1. View Products");
                Console.WriteLine("2. Add to Cart");
                Console.WriteLine("3. View Cart");
                Console.WriteLine("4. Checkout");
                Console.WriteLine("5. Logout");
                Console.Write("Choose option: ");
                int choice = Convert.ToInt32(Console.ReadLine());


                static void ViewProducts()
                {
                    Console.WriteLine("\n=== Products ===");
                    foreach (var p in products)
                    {
                        Console.WriteLine($"{p.ProductId}. {p.ProductName} - {p.Price:C} ({p.Brand})");
                    }
                }

                static void AddToCart(Customer customer)
                {
                                       ViewProducts();
                    Console.Write("Enter product ID to add to cart: ");
                    int productId = Convert.ToInt32(Console.ReadLine());
                    var product = products.Find(p => p.ProductId == productId);
                    if (product == null)
                    {
                        Console.WriteLine("Product not found.");
                        return;
                    }
                    Console.Write("Enter quantity: ");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    if (quantity <= 0 || quantity > product.StockQuantity)
                    {
                        Console.WriteLine("Invalid quantity.");
                        return;
                    }
                    customer.Cart.AddProduct(product, quantity);
                    product.StockQuantity -= quantity; // Uppdatera lagersaldo
                    Console.WriteLine($"{quantity} x {product.ProductName} added to cart.");
                }

                static void ViewCart(Customer customer)
                {
                    Console.WriteLine("\n=== Your Cart ===");

                    if (customer.Cart.CartItems.Count == 0)
                    {
                        Console.WriteLine("Your cart is empty.");
                        return;
                    }

                    foreach (var product in customer.Cart.CartItems)
                    {
                        int quantity = customer.Cart.ProductQuantities[product.ProductId];
                        decimal itemTotal = product.Price * quantity;
                        Console.WriteLine($"{product.ProductName} x{quantity} - {itemTotal:C}");
                    }

                    Console.WriteLine($"\nTotal: {customer.Cart.TotalPrice:C}");
                }

                static void Checkout(Customer customer)
                {
                    if (customer.Cart.CartItems.Count == 0)
                    {
                        Console.WriteLine("Your cart is empty.");
                        return;
                    }

                    Console.WriteLine($"\nTotal: {customer.Cart.TotalPrice:C}");
                    Console.Write("Enter delivery address: ");
                    string address = Console.ReadLine();

                    Console.Write("Proceed to checkout? (y/n): ");
                    if (Console.ReadLine().ToLower() != "y")
                    {
                        Console.WriteLine("Checkout cancelled.");
                        return;
                    }

                    OrderClass order = new OrderClass();
                    order.CreateOrder(customer.Name, customer.Cart.CartItems, customer.Cart.ProductQuantities);

                    DeliverySystem delivery = new DeliverySystem();
                    delivery.OrderID = order.GetOrderID();
                    delivery.DeliveryAddress = address;
                    delivery.ScheduleDelivery(DateTime.Now.AddDays(3));

                    Console.WriteLine("\nOrder placed successfully!");
                    delivery.TrackDelivery();

                    customer.Cart.ClearCart();
                }


                if (choice == 1)
                {
                    ViewProducts();
                }

                else if (choice == 2 )
                {
                    AddToCart(customer);
                }
                
                else if (choice == 3)
                {
                    ViewCart(customer);
                }
                else if (choice == 4)
                {
                    Checkout(customer);
                }
                else if (choice == 5)
                {
                    inMenu = false;
                    Console.WriteLine("Logged out!");
                }
            }
        }











        static void AdminLogin()
        {
            Console.WriteLine("\nAdmin Login");
            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            foreach (var admin in admins)
            {
                if (admin.Login(email, password))
                {
                    Console.WriteLine($"Welcome back, Admin {admin.Name}!");
                    return;
                }
            }
        }
        static void CreateAccount()
        {
            Console.WriteLine("\nCreate account as: 1) Customer  2) Admin");
            int accountType = Convert.ToInt32(Console.ReadLine());

            if (accountType == 1)
            {
                Customer customer = new Customer();
                customer.CreateAccount();
                customers.Add(customer); // Spara i listan!
            }
            else if (accountType == 2)
            {
                Admin admin = new Admin();
                admin.CreateAccount();
                admins.Add(admin); // Spara i listan!
            }
        }
    }
}