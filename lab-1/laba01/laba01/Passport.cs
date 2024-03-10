using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba01
{
    public class Passport : IndividualDocument
    {
        public string IdentificationCode { get; set; }

        public Passport(string name, string photo, string identificationCode)
            : base(name, photo)
        {
            IdentificationCode = identificationCode;
        }

        public override void ShowAllDetails()
        {
            Console.WriteLine($"Identification Code: {IdentificationCode}");
        }

        public override void PerformIndividualAction()
        {
            DocumentOperation.CopyIdentificationCode(this);
        }
    }
}
