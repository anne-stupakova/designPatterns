using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba01
{
    public class DriverLicense : IndividualDocument
    {
        public string Category { get; set; }

        public DriverLicense(string name, string photo, string category)
            : base(name, photo)
        {
            Category = category;
        }

        public override void ShowAllDetails()
        {
            Console.WriteLine($"Category: {Category}");
        }

        public override void PerformIndividualAction()
        {
            DocumentOperation.RegisterVehicle(this);
        }
    }
}
