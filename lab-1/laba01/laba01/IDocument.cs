using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba01
{
    public interface IDocument
    {
        public string Name { get; set; }
        public string Photo { get; set; }
        void ShowInfo();
        void GenerateQR();
        void ShowAllDetails();
        void DisplaySubMenu(Action[] actions, string[] actionNames);
    }

    public interface IIndividualDocument : IDocument
    {
        void PerformIndividualAction();
    }
}
