using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    interface IRenderer
    {
        void RenderShape(string shape);
    }

    class VectorRenderer : IRenderer
    {
        public void RenderShape(string shape)
        {
            Console.WriteLine($"Drawing {shape} as vector graphics");
        }
    }

    class RasterRenderer : IRenderer
    {
        public void RenderShape(string shape)
        {
            Console.WriteLine($"Drawing {shape} as pixels");
        }
    }
}
