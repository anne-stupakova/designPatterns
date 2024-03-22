using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public abstract class SubscriptionFactory
    {
        public abstract ISubscription CreateSubscription(decimal monthlyFee, int minSubscriptionMonths, List<string> channels, string creationMethod);
    }
}
