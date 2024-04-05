using System;

namespace task3
{
    class Client
    {
        public void ClientCode(ShapeAbstraction abstraction)
        {
            abstraction.Draw();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            IRenderer vectorRenderer = new VectorRenderer();
            IRenderer rasterRenderer = new RasterRenderer();

            ShapeAbstraction circle = new CircleAbstraction(vectorRenderer);
            ShapeAbstraction square = new SquareAbstraction(rasterRenderer);
            ShapeAbstraction triangle = new TriangleAbstraction(vectorRenderer);

            client.ClientCode(circle);
            client.ClientCode(square);
            client.ClientCode(triangle);
        }
    }
}
