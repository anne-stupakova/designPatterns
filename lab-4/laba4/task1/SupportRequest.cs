using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class SupportRequest
    {
        public enum SupportLevel
        {
            Level1,
            Level2,
            Level3,
            Level4
        }
        public SupportLevel RequestedLevel { get; set; }
    }
}
