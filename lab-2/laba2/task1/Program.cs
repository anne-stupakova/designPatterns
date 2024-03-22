using System;
using System.Collections.Generic;

namespace task1
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Choose subscription type:");
            Console.WriteLine("1. Domestic Subscription");
            Console.WriteLine("2. Educational Subscription");
            Console.WriteLine("3. Premium Subscription");

            Console.Write("Enter your choice: ");
            int subscriptionChoice = int.Parse(Console.ReadLine());

            SubscriptionFactory subscriptionFactory = null;
            switch (subscriptionChoice)
            {
                case 1:
                    subscriptionFactory = new WebSite();
                    break;
                case 2:
                    subscriptionFactory = new MobileApp();
                    break;
                case 3:
                    subscriptionFactory = new ManagerCall();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            Console.WriteLine("Choose subscription creation method:");
            Console.WriteLine("1. Website");
            Console.WriteLine("2. Mobile App");
            Console.WriteLine("3. Manager Call");

            Console.Write("Enter creation method: ");
            int creationMethodChoice = int.Parse(Console.ReadLine());

            string creationMethod = "";
            switch (creationMethodChoice)
            {
                case 1:
                    creationMethod = "Website";
                    break;
                case 2:
                    creationMethod = "Mobile App";
                    break;
                case 3:
                    creationMethod = "Manager Call";
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            decimal monthlyFee;
            int minSubscriptionMonths;
            List<string> channels = new List<string>();

            Console.Write("Enter monthly fee: ");
            monthlyFee = decimal.Parse(Console.ReadLine());

            Console.Write("Enter minimum subscription months: ");
            minSubscriptionMonths = int.Parse(Console.ReadLine());

            Console.Write("Enter channels (separated by comma): ");
            channels.AddRange(Console.ReadLine().Split(','));

            ISubscription subscription = subscriptionFactory.CreateSubscription(monthlyFee, minSubscriptionMonths, channels, creationMethod);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Chosen Subscription:");
            Console.ResetColor();
            subscription.DisplayInfo();
        }
    }
}