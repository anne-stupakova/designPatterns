using System;
using static System.Net.Mime.MediaTypeNames;
namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            IHero warrior = new Warrior();
            warrior = new ArmorDecorator(warrior);
            warrior = new WeaponDecorator(warrior);

            IHero mage = new Mage();
            mage = new WeaponDecorator(mage);
            mage = new ArtifactDecorator(mage);

            IHero paladin = new Paladin();
            paladin = new ArmorDecorator(paladin);
            paladin = new ArtifactDecorator(paladin);

            warrior.ShowInfo();
            Console.WriteLine();

            mage.ShowInfo();
            Console.WriteLine();

            paladin.ShowInfo();
        }
    }
}
