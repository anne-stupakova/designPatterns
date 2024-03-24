using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class EnemyBuilder : ICharacterBuilder
    {
        private Character character;

        public EnemyBuilder()
        {
            character = new Character();
        }

        public ICharacterBuilder SetName(string name)
        {
            character.Name = name;
            return this;
        }

        public ICharacterBuilder SetHeight(int height)
        {
            character.Height = height;
            return this;
        }

        public ICharacterBuilder SetBuild(string build)
        {
            character.Build = build;
            return this;
        }

        public ICharacterBuilder SetHairColor(string hairColor)
        {
            character.HairColor = hairColor;
            return this;
        }

        public ICharacterBuilder SetEyeColor(string eyeColor)
        {
            character.EyeColor = eyeColor;
            return this;
        }

        public ICharacterBuilder SetClothing(string clothing)
        {
            character.Clothing = clothing;
            return this;
        }

        public ICharacterBuilder AddToInventory(string item)
        {
            character.Inventory.Add(item);
            return this;
        }

        public ICharacterBuilder AddGoodDeed(string deed)
        {
            character.GoodDeeds.Add(deed);
            return this;
        }

        public ICharacterBuilder AddEvilDeed(string deed)
        {
            character.EvilDeeds.Add(deed);
            return this;
        }

        public Character Build()
        {
            return character;
        }
    }
}
