using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    abstract class InventoryDecorator : IHero
    {
        protected IHero hero;

        public InventoryDecorator(IHero hero)
        {
            this.hero = hero;
        }

        public virtual void ShowInfo()
        {
            if (hero != null)
            {
                hero.ShowInfo();
            }
        }
    }

    class ArmorDecorator : InventoryDecorator
    {
        public ArmorDecorator(IHero hero) : base(hero)
        {
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Equipped with Armor");
        }
    }

    class WeaponDecorator : InventoryDecorator
    {
        public WeaponDecorator(IHero hero) : base(hero)
        {
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Equipped with Weapon");
        }
    }

    class ArtifactDecorator : InventoryDecorator
    {
        public ArtifactDecorator(IHero hero) : base(hero)
        {
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Equipped with Artifact");
        }
    }
}
