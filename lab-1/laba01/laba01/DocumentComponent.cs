using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba01
{
    public class DocumentComponent : IDocument, IIndividualDocument
    {
        private readonly IDocument baseDocument;

        public DocumentComponent(IDocument baseDocument)
        {
            this.baseDocument = baseDocument;
        }

        public string Name
        {
            get => baseDocument.Name;
            set => baseDocument.Name = value;
        }

        public string Photo
        {
            get => baseDocument.Photo;
            set => baseDocument.Photo = value;
        }

        public void ShowInfo()
        {
            baseDocument.ShowInfo();
        }

        public void GenerateQR()
        {
            baseDocument.GenerateQR();
        }

        public void ShowAllDetails()
        {
            baseDocument.ShowAllDetails();
        }

        public void DisplaySubMenu(Action[] actions, string[] actionNames)
        {
            bool exitSubMenu = false;

            do
            {
                Console.WriteLine("\nSubmenu:");

                for (int i = 0; i < actions.Length; i++)
                {
                    if (actions[i] != null && actions[i].Method != null)
                    {
                        Console.WriteLine($"{i + 1}. {actionNames[i]}");
                    }
                }

                Console.WriteLine("0. Back");

                int submenuChoice;
                while (!int.TryParse(Console.ReadLine(), out submenuChoice) || submenuChoice < 0 || submenuChoice > actions.Length)
                {
                    Console.WriteLine("Invalid choice. Please enter a valid submenu number.");
                }

                if (submenuChoice == 0)
                {
                    exitSubMenu = true;
                }
                else
                {
                    actions[submenuChoice - 1]?.Invoke();
                }
            } while (!exitSubMenu);
        }


        public void PerformIndividualAction()
        {
            // Default implementation
        }
    }
}
