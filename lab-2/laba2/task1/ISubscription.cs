using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public interface ISubscription
    {
        decimal MonthlyFee { get; }
        int MinSubscriptionMonths { get; }
        List<string> Channels { get; }
        void DisplayInfo();
    }
}
