using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slides.Shapes
{
    public struct Rect
    {
        public double Left { get; }
        public double Top { get; }
        public double Width { get; }
        public double Height { get; }

        public Rect(double left, double top, double width, double height)
        {
            Left = left;
            Width = width;
            Top = top;
            Height = height;
        }
    }
}
