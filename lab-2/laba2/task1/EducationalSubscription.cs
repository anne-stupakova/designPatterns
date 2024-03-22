using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class EducationalSubscription : ISubscription
    {
        public decimal MonthlyFee { get; private set; }
        public int MinSubscriptionMonths { get; private set; }
        public List<string> Channels { get; private set; }

        public EducationalSubscription(decimal monthlyFee, int minSubscriptionMonths, List<string> channels)
        {
            MonthlyFee = monthlyFee;
            MinSubscriptionMonths = minSubscriptionMonths;
            Channels = channels;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Educational Subscription:");
            Console.WriteLine($"Monthly Fee: {MonthlyFee}");
            Console.WriteLine($"Minimum Subscription Months: {MinSubscriptionMonths}");
            Console.WriteLine("Channels:");
            foreach (var channel in Channels)
            {
                Console.WriteLine(channel);
            }
        }
    }
}
