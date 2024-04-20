using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class TextEditor
    {
        private TextDocument _document;
        private Stack<TextDocumentMemento> _mementos;

        public TextEditor(string content)
        {
            _document = new TextDocument(content);
            _mementos = new Stack<TextDocumentMemento>();
        }

        public void Save()
        {
            TextDocumentMemento memento = _document.CreateMemento();
            _mementos.Push(memento);
            Console.WriteLine("Document saved.");
        }

        public void Undo()
        {
            if (_mementos.Count > 0)
            {
                TextDocumentMemento memento = _mementos.Pop();
                _document.RestoreMemento(memento);
                Console.WriteLine("Undo successful.");
            }
            else
            {
                Console.WriteLine("Nothing to undo.");
            }
        }

        public void EditContent(string newContent)
        {
            _document.EditContent(newContent);
            Console.WriteLine("Content edited.");
        }

        public void PrintContent()
        {
            Console.WriteLine("Current Content:");
            Console.WriteLine(_document.GetContent());
        }
    }
}
