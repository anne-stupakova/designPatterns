using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class FileWriter
    {
        private StreamWriter streamWriter;

        public FileWriter(string filePath)
        {
            streamWriter = new StreamWriter(filePath, true);
        }

        public void Write(string message)
        {
            streamWriter.Write(message);
        }

        public void WriteLine(string message)
        {
            streamWriter.WriteLine(message);
        }

        public void Close()
        {
            streamWriter.Close();
        }
    }
}
