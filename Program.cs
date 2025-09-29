namespace ECommerceSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to ECommerceSystem:\nChoose 1 if you are customer\nChoose 2 if you are admin\nChoose 3 to create an account.");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                // TODO: Customer Login (kommer senare)
                Console.WriteLine("Customer login - Coming soon!");
            }
            else if (choice == 2)
            {
                // TODO: Admin Login (kommer senare)
                Console.WriteLine("Admin login - Coming soon!");
            }
            else if (choice == 3)
            {
                Console.WriteLine("Create account as: 1) Customer  2) Admin");
                int accountType = Convert.ToInt32(Console.ReadLine());

                if (accountType == 1)
                {
                    Customer customer = new Customer();
                    customer.CreateAccount();
                }
                else if (accountType == 2)
                {
                    Admin admin = new Admin();
                    admin.CreateAccount();
                }
            }

        }
    }
}
