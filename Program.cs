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
                Customer customer = new Customer();
                customer.CreateAccount();
            }
            else if (choice == 2)
            {
                Admin admin = new Admin();
            }
            else if (choice == 3)
            {
                CreateAccount createAccount = new CreateAccount();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please restart the application and choose a valid option.");
            }
            
        }
    }
}
