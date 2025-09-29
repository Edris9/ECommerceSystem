using System.Security.Cryptography;
using System.Text;

namespace ECommerceSystem
{
    internal class Customer
    {
        // user details
        public string Name { get; set; }
        public string LastName { get; set; }
        private string Email { get; set; }
        private string Password { get; set; }
        // get user details
        public void CreateAccount()
        {
            Console.WriteLine("Enter your name:");
            Name = Console.ReadLine();
            Console.WriteLine("Enter your last name:");
            LastName = Console.ReadLine();

            Console.WriteLine("Enter your email:");
            Email = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            Password = Console.ReadLine();
            Console.WriteLine($"\nAccount successfully created for {Name} {LastName}!");
        }

    }
}