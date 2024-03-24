using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class Character
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public string Build { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Clothing { get; set; }
        public List<string> Inventory { get; set; }
        public List<string> GoodDeeds { get; set; }
        public List<string> EvilDeeds { get; set; }

        public Character()
        {
            Inventory = new List<string>();
            GoodDeeds = new List<string>();
            EvilDeeds = new List<string>();
        }

        public void DisplayCharacter()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Height: {Height} cm");
            Console.WriteLine($"Build: {Build}");
            Console.WriteLine($"Hair Color: {HairColor}");
            Console.WriteLine($"Eye Color: {EyeColor}");
            Console.WriteLine($"Clothing: {Clothing}");
            Console.WriteLine("Inventory:");
            foreach (var item in Inventory)
            {
                Console.WriteLine($"- {item}");
            }
            Console.WriteLine("Good Deeds:");
            foreach (var deed in GoodDeeds)
            {
                Console.WriteLine($"- {deed}");
            }
            Console.WriteLine("Evil Deeds:");
            foreach (var deed in EvilDeeds)
            {
                Console.WriteLine($"- {deed}");
            }
        }
    }
}
