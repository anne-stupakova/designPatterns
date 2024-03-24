using System;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Virus parentVirus = new Virus(10, 1, "ParentVirus", "Type1");

            parentVirus.AddChild(new Virus(5, 0, "Child1", "Type2"));
            parentVirus.AddChild(new Virus(7, 0, "Child2", "Type2"));
            parentVirus.AddChild(new Virus(3, 0, "Child3", "Type2"));

            parentVirus.Children[0].AddChild(new Virus(2, 0, "Grandchild1", "Type3"));
            parentVirus.Children[0].AddChild(new Virus(4, 0, "Grandchild2", "Type3"));

            parentVirus.Children[0].Children[0].AddChild(new Virus(1, 0, "Great-grandchild1", "Type4"));
            parentVirus.Children[0].Children[0].AddChild(new Virus(3, 0, "Great-grandchild2", "Type4"));

            Virus clonedVirus = (Virus)parentVirus.Clone();

            Console.WriteLine("Original Virus:");
            DisplayVirus(parentVirus);

            Console.WriteLine("\nCloned Virus:");
            DisplayVirus(clonedVirus);
        }

        static void DisplayVirus(Virus virus, string prefix = "")
        {
            Console.WriteLine($"{prefix}Name: {virus.Name}, Type: {virus.Type}, Weight: {virus.Weight}, Age: {virus.Age}");
            if (virus.Children.Length > 0)
            {
                Console.WriteLine($"{prefix}Children:");
                foreach (var child in virus.Children)
                {
                    DisplayVirus(child, prefix + "  ");
                }
            }
        }
    }
}
