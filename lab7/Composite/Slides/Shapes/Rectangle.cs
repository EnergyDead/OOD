using Slides.Styles;
using System.Collections.Generic;

namespace Slides.Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(Rect frame, IOutlineStyle outlineStyle, IStyle fillStyle)
            : base(frame, outlineStyle, fillStyle)
        {
        }

        public override void Draw(ICanvas canvas)
        {
            List<Point> points = new List<Point>
            {
                new Point(_frame.Left, _frame.Top),
                new Point(_frame.Left + _frame.Width, _frame.Top),
                new Point(_frame.Left + _frame.Width, _frame.Top + _frame.Height),
                new Point(_frame.Left, _frame.Top + _frame.Height)
            };

            if (_fillStyle.IsEnabled().HasValue && _fillStyle.IsEnabled().Value && _fillStyle.GetColor() != null)
            {
                canvas.SetFillColor(_fillStyle.GetColor());
                canvas.FillPolygon(points);
            }
            if (_outlineStyle.IsEnabled().HasValue && _outlineStyle.IsEnabled().Value && _outlineStyle.GetColor() != null)
            {
                canvas.SetOutlineThickness(_outlineStyle.GetOutlineThickness() ?? 1);
                canvas.SetOutlineColor(_outlineStyle.GetColor());

                canvas.DrawLine(points[0], points[1]);
                canvas.DrawLine(points[1], points[2]);
                canvas.DrawLine(points[2], points[3]);
                canvas.DrawLine(points[3], points[0]);
            }
        }
    }
}
