using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    public class SmartTextChecker : ITextReader
    {
        private SmartTextReader _realReader;

        public char[,] ReadText(string filePath)
        {
            Log("Opened file: " + filePath);

            if (_realReader == null)
            {
                _realReader = new SmartTextReader();
            }

            char[,] result = _realReader.ReadText(filePath);

            Log("Read file: " + filePath);
            Log("Closed file: " + filePath);

            return result;
        }

        private void Log(string message)
        {
            Console.WriteLine("Proxy: " + message);
        }
    }
}
