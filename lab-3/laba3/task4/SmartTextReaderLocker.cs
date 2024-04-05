using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace task4
{
    public class SmartTextReaderLocker : ITextReader
    {
        private readonly Regex _filePattern;
        private readonly ITextReader _realReader;

        public SmartTextReaderLocker(string filePattern)
        {
            _filePattern = new Regex(filePattern);
            _realReader = new SmartTextReader();
        }

        public char[,] ReadText(string filePath)
        {
            if (_filePattern.IsMatch(filePath))
            {
                Console.WriteLine("Access denied to file: " + Path.GetFileName(filePath));
                return null;
            }
            else
            {
                return _realReader.ReadText(filePath);
            }
        }
    }
}
