namespace ECommerceSystem
{
    internal class Program
    {
        static List<Customer> customers = new List<Customer>();
        static List<Admin> admins = new List<Admin>();
        static List<Product> products = new List<Product>();

        static void Main(string[] args)
        {
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
                    return;
                }
            }
            Console.WriteLine("Invalid email or password.");
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