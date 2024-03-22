using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class MobileApp : SubscriptionFactory
    {
        public override ISubscription CreateSubscription(decimal monthlyFee, int minSubscriptionMonths, List<string> channels, string creationMethod)
        {
            if (minSubscriptionMonths > 6)
            {
                return new PremiumSubscription(monthlyFee, minSubscriptionMonths, channels);
            }
            else
            {
                return new EducationalSubscription(monthlyFee, minSubscriptionMonths, channels);
            }
        }
    }
}
