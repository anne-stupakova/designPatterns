using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    public class SmartTextReader : ITextReader
    {
        public char[,] ReadText(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            char[,] result = new char[lines.Length, lines[0].Length];

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    result[i, j] = lines[i][j];
                }
            }

            return result;
        }
    }
}
