using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    interface IHero
    {
        void ShowInfo();
    }

    class Warrior : IHero
    {
        public void ShowInfo()
        {
            Console.WriteLine("Warrior");
        }
    }
    class Mage : IHero
    {
        public void ShowInfo()
        {
            Console.WriteLine("Mage");
        }
    }

    class Paladin : IHero
    {
        public void ShowInfo()
        {
            Console.WriteLine("Paladin");
        }
    }
}
