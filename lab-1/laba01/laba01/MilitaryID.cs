using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba01
{
    public class MilitaryID : IndividualDocument
    {
        public string Rank { get; set; }

        public MilitaryID(string name, string photo, string rank)
            : base(name, photo)
        {
            Rank = rank;
        }

        public override void ShowAllDetails()
        {
            Console.WriteLine($"Rank: {Rank}");
        }
    }
}
