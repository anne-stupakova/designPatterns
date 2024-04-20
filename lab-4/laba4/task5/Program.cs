namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter initial document content:");
            string initialContent = Console.ReadLine();

            TextEditor editor = new TextEditor(initialContent);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nChoose an action:");
                Console.WriteLine("1. Save");
                Console.WriteLine("2. Undo");
                Console.WriteLine("3. Edit Content");
                Console.WriteLine("4. Print Current Content");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        editor.Save();
                        break;
                    case "2":
                        editor.Undo();
                        break;
                    case "3":
                        Console.WriteLine("Enter new content:");
                        string newContent = Console.ReadLine();
                        editor.EditContent(newContent);
                        break;
                    case "4":
                        editor.PrintContent();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

            Console.WriteLine("Exiting the editor.");
        }
    }
}