using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba01
{
    public abstract class IndividualDocument : IIndividualDocument
    {
        private readonly DocumentComponent documentComponent;

        public IndividualDocument(string name, string photo)
        {
            documentComponent = new DocumentComponent(this);
            Name = name;
            Photo = photo;
        }

        public string Name { get; set; }
        public string Photo { get; set; }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Name: {Name}, Photo: {Photo}");
        }

        public virtual void GenerateQR()
        {
            Console.WriteLine("QR code generated.");
        }

        public virtual void ShowAllDetails()
        {
            // By default, an empty method in the base class
        }

        public void DisplaySubMenu(Action[] actions, string[] actionNames)
        {
            documentComponent.DisplaySubMenu(actions, actionNames);
        }

        public virtual void PerformIndividualAction()
        {
            // Default implementation
        }
    }
}
