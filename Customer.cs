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
        public virtual void CreateAccount()
        {
            Console.WriteLine("Enter your name:");
            Name = Console.ReadLine();
            Console.WriteLine("Enter your last name:");
            LastName = Console.ReadLine();
            Console.WriteLine("Enter your email:");
            Email = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            Password = HashPassword(Console.ReadLine());
            Console.WriteLine($"\nAccount successfully created for {Name} {LastName}!");
        }

        // Hash password
        protected string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        // Login metod
        public bool Login(string email, string password)
        {
            string hashedInput = HashPassword(password);
            return this.Email == email && this.Password == hashedInput;
        }
    }
}