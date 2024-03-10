using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba01
{
    public class DocumentContainer
    {
        private List<IDocument> documents;

        public DocumentContainer()
        {
            documents = new List<IDocument>
        {
            new Passport("Ann Stupakova", "passport.jpg", "82539634123456"),
            new DriverLicense("Ann Stupakova", "license.jpg", "B"),
            new MilitaryID("Ann Stupakova", "militaryid.jpg", "Captain")
        };
        }

        public void ChangeDocumentOrder()
        {
            documents.Reverse();
            Console.WriteLine("Document order changed.");
        }

        public void DisplayAllDocuments()
        {
            Console.WriteLine("\nChoose a document to view:");

            for (int i = 0; i < documents.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {documents[i].GetType().Name}");
            }

            int documentChoice;
            while (!int.TryParse(Console.ReadLine(), out documentChoice) || documentChoice < 1 || documentChoice > documents.Count)
            {
                Console.WriteLine("Invalid choice. Please enter a valid document number.");
            }

            Console.WriteLine("\nChoose the display format:");
            Console.WriteLine("1. List");
            Console.WriteLine("2. Table");

            int displayChoice;
            while (!int.TryParse(Console.ReadLine(), out displayChoice) || displayChoice < 1 || displayChoice > 2)
            {
                Console.WriteLine("Invalid choice. Please enter a valid display format number.");
            }

            switch (displayChoice)
            {
                case 1:
                    DisplayDocumentList(documents[documentChoice - 1]);
                    break;
                case 2:
                    DisplayDocumentTable(documents[documentChoice - 1]);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }


        private void DisplayDocumentList(IDocument document)
        {
            Console.WriteLine("\nDisplaying as List:");
            document.ShowInfo();
            DisplayIndividualActions(document);
        }

        private void DisplayDocumentTable(IDocument document)
        {
            Console.WriteLine("\nDisplaying as Table:");
            Console.WriteLine($"Name\t\t|Photo");
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"{document.Name}\t|{document.Photo}");
            DisplayIndividualActions(document);
        }

        private void DisplayIndividualActions(IDocument document)
        {
            Action[] actions = GetIndividualActions(document);
            string[] actionNames = GetIndividualActionNames(document);

            if (actions.Length > 0)
            {
                document.DisplaySubMenu(actions, actionNames);
            }
            else
            {
                document.DisplaySubMenu(new Action[] { document.ShowAllDetails, document.GenerateQR },
                    new string[] { "Show All Details", "Generate QR" });
            }
        }
        private Action[] GetIndividualActions(IDocument document)
        {
            return document switch
            {
                IIndividualDocument individualDocument when individualDocument is Passport passport =>
                    new Action[] { document.ShowAllDetails, document.GenerateQR, () => DocumentOperation.CopyIdentificationCode(passport) },
                IIndividualDocument individualDocument when individualDocument is DriverLicense license =>
                    new Action[] { document.ShowAllDetails, document.GenerateQR, () => DocumentOperation.RegisterVehicle(license) },
                _ => new Action[0]
            };
        }

        private string[] GetIndividualActionNames(IDocument document)
        {
            return document switch
            {
                IIndividualDocument individualDocument when individualDocument is Passport =>
                    new string[] { "Show All Details", "Generate QR", "Copy Identification Code" },
                IIndividualDocument individualDocument when individualDocument is DriverLicense =>
                    new string[] { "Show All Details", "Generate QR", "Register Vehicle" },
                _ => new string[0]
            };
        }
    }

    public class DocumentOperation
    {
        public static void CopyIdentificationCode(Passport passport)
        {
            Console.WriteLine("Identification code copied.");
        }

        public static void RegisterVehicle(DriverLicense license)
        {
            Console.WriteLine("Vehicle registered.");
        }
    }
}
