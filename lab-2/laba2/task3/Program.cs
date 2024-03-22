using System;

namespace task3
{
    class Program
    {
        static void Main()
        {
            Authenticator authenticator = Authenticator.GetInstance();

            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if (authenticator.Authenticate(username, password))
            {
                Console.WriteLine("Authentication successful!");
            }
            else
            {
                Console.WriteLine("Authentication failed!");
            }
        }
    }
}