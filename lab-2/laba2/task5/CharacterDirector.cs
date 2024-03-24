using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class CharacterDirector
    {
        private ICharacterBuilder heroBuilder;
        private ICharacterBuilder enemyBuilder;

        public event EventHandler Event;

        public CharacterDirector(ICharacterBuilder heroBuilder, ICharacterBuilder enemyBuilder)
        {
            this.heroBuilder = heroBuilder;
            this.enemyBuilder = enemyBuilder;
        }

        public Character ConstructCharacterHero()
        {
            return heroBuilder
                .SetName("Danilo")
                .SetHeight(180)
                .SetBuild("Muscular")
                .SetHairColor("Blonde")
                .SetEyeColor("Blue")
                .SetClothing("Pixel")
                .AddToInventory("FPV")
                .AddToInventory("M16")
                .AddGoodDeed("The destruction of the russians)")
                .Build();
        }

        public Character ConstructCharacterEnemy()
        {
            return enemyBuilder
                .SetName("Gordei")
                .SetHeight(174)
                .SetBuild("Slim")
                .SetHairColor("Black")
                .SetEyeColor("Black")
                .SetClothing("Something...")
                .AddToInventory("AK-74")
                .AddToInventory("Shahed")
                .AddEvilDeed("Existence")
                .Build();
        }
    }
}
