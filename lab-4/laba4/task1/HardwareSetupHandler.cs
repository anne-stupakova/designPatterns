using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class HardwareSetupHandler : SupportHandler
    {
        public override void HandleRequest(SupportRequest request)
        {
            if (request.RequestedLevel == SupportRequest.SupportLevel.Level2)
            {
                Console.WriteLine("How can I assist you with hardware setup?");
                string userResponse = Console.ReadLine();

                if (!string.IsNullOrEmpty(userResponse))
                {
                    Console.WriteLine("Your request has been forwarded to the operator. Please wait for a call.");
                }
                else
                {
                    NextHandler.HandleRequest(request);
                }
            }
            else if (NextHandler != null)
            {
                NextHandler.HandleRequest(request);
            }
            else
            {
                Console.WriteLine("No suitable support level found.");
            }
        }
    }
}
