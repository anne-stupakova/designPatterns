using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class SupportSystem
    {
        private readonly SupportHandler _firstHandler;

        public SupportSystem()
        {
            _firstHandler = new NetworkConnectionHandler();
            var hardwareHandler = new HardwareSetupHandler();
            var audioVideoHandler = new AudioVideoIssuesHandler();
            var softwareHandler = new SoftwareIssuesHandler();

            _firstHandler.SetNextHandler(hardwareHandler);
            hardwareHandler.SetNextHandler(audioVideoHandler);
            audioVideoHandler.SetNextHandler(softwareHandler);
        }

        public void ProcessRequest(SupportRequest request)
        {
            Console.WriteLine("Your support level: " + request.RequestedLevel);
            _firstHandler.HandleRequest(request);
        }
    }
}
