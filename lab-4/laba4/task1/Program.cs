namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            SupportSystem supportSystem = new SupportSystem();
            SupportRequest request = new SupportRequest();

            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("Please answer the following questions to determine the level of support you need:");
                Console.WriteLine("Are you experiencing issues with network connection? (Yes/No)");
                string networkAnswer = Console.ReadLine().ToLower();

                Console.WriteLine("Do you need assistance with hardware setup? (Yes/No)");
                string hardwareAnswer = Console.ReadLine().ToLower();

                Console.WriteLine("Are you experiencing audio or video issues? (Yes/No)");
                string audioVideoAnswer = Console.ReadLine().ToLower();

                Console.WriteLine("Do you have issues with software or applications? (Yes/No)");
                string softwareAnswer = Console.ReadLine().ToLower();

                if (networkAnswer == "yes")
                {
                    request.RequestedLevel = SupportRequest.SupportLevel.Level1;
                    validInput = true;
                }
                else if (hardwareAnswer == "yes")
                {
                    request.RequestedLevel = SupportRequest.SupportLevel.Level2;
                    validInput = true;
                }
                else if (audioVideoAnswer == "yes")
                {
                    request.RequestedLevel = SupportRequest.SupportLevel.Level3;
                    validInput = true;
                }
                else if (softwareAnswer == "yes")
                {
                    request.RequestedLevel = SupportRequest.SupportLevel.Level4;
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Please provide a valid response (Yes/No) for each question.");
                }
            }

            supportSystem.ProcessRequest(request);

            Console.ReadLine();
        }
    }
}
