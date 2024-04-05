using System;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "log.txt";

            FileWriter fileWriter = new FileWriter(filePath);

            ILogger fileLogger = new FileLoggerAdapter(fileWriter);

            Random random = new Random();
            int operand1 = random.Next(1, 11);
            int operand2 = random.Next(1, 11);
            int result = operand1 * operand2;

            Console.WriteLine($"Calculate the result of {operand1} * {operand2}:");

            string userInput = Console.ReadLine();
            int userResult;
            if (int.TryParse(userInput, out userResult))
            {
                if (userResult == result)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct!");
                    Console.ResetColor();
                    fileLogger.Log($"User answered correctly: {operand1} * {operand2} = {userResult}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect result. Please try again.");
                    Console.ResetColor();
                    fileLogger.Error($"User answered incorrectly: {operand1} * {operand2} = {userResult}, correct answer is {result}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Invalid format. Please enter a valid number.");
                Console.ResetColor();
                fileLogger.Warn($"User entered invalid format: {userInput}");
            }

            fileWriter.Close();


            Console.ReadLine();
        }
    }
}
