using System;

namespace laba01
{
    class Program
    {
        static void Main()
        {
            DocumentContainer container = new DocumentContainer();

            while (true)
            {
                Console.WriteLine("\n1. Display All Documents");
                Console.WriteLine("2. Change Document Order");
                Console.WriteLine("0. Exit");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            container.DisplayAllDocuments();
                            break;
                        case 2:
                            container.ChangeDocumentOrder();
                            break;
                        case 0:
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }
        }
    }

}
