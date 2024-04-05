using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class ShapeAbstraction
    {
        protected IRenderer _renderer;

        public ShapeAbstraction(IRenderer renderer)
        {
            this._renderer = renderer;
        }

        public virtual void Draw()
        {
            _renderer.RenderShape("Shape");
        }
    }

    class CircleAbstraction : ShapeAbstraction
    {
        public CircleAbstraction(IRenderer renderer) : base(renderer)
        {
        }

        public override void Draw()
        {
            base._renderer.RenderShape("Circle");
        }
    }

    class SquareAbstraction : ShapeAbstraction
    {
        public SquareAbstraction(IRenderer renderer) : base(renderer)
        {
        }

        public override void Draw()
        {
            base._renderer.RenderShape("Square");
        }
    }

    class TriangleAbstraction : ShapeAbstraction
    {
        public TriangleAbstraction(IRenderer renderer) : base(renderer)
        {
        }

        public override void Draw()
        {
            base._renderer.RenderShape("Triangle");
        }
    }
}
