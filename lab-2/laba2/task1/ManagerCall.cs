using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class ManagerCall : SubscriptionFactory
    {
        public override ISubscription CreateSubscription(decimal monthlyFee, int minSubscriptionMonths, List<string> channels, string creationMethod)
        {
            if (channels.Contains("Special Channel"))
            {
                return new PremiumSubscription(monthlyFee, minSubscriptionMonths, channels);
            }
            else
            {
                return new DomesticSubscription(monthlyFee, minSubscriptionMonths, channels);
            }
        }
    }
}
