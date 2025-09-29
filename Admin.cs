namespace ECommerceSystem
{
    internal class Admin : Customer
    {
        public string AdminID { get; set; }
        public string Role { get; set; } = "Admin";

        public virtual void CreateAccount()
        {
            base.CreateAccount(); 

            Console.WriteLine("Enter your Admin ID:");
            AdminID = Console.ReadLine();

            Console.WriteLine($"\nAdmin account successfully created for {Name}!");
            Console.WriteLine($"Role: {Role}");
        }
    }
}