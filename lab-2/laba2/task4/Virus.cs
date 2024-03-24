using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    public class Virus : ICloneable
    {
        public int Weight;
        public int Age;
        public string Name;
        public string Type;
        public Virus[] Children;

        public Virus(int weight, int age, string name, string type)
        {
            Weight = weight;
            Age = age;
            Name = name;
            Type = type;
            Children = new Virus[0];
        }

        public void AddChild(Virus child)
        {
            Array.Resize(ref Children, Children.Length + 1);
            Children[Children.Length - 1] = child;
        }

        public object Clone()
        {
            Virus clone = (Virus)this.MemberwiseClone();
            clone.Children = new Virus[Children.Length];
            for (int i = 0; i < Children.Length; i++)
            {
                clone.Children[i] = (Virus)Children[i].Clone();
            }
            return clone;
        }
    }
}
