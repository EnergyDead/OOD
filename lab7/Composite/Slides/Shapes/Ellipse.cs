using Slides.Styles;

namespace Slides.Shapes
{
    public class Ellipse : Shape
    {
        public Ellipse(Rect frame, IOutlineStyle outlineStyle, IStyle fillStyle)
            : base(frame, outlineStyle, fillStyle)
        {
        }

        public override void Draw(ICanvas canvas)
        {
            if (_fillStyle.IsEnabled().HasValue && _fillStyle.IsEnabled().Value && _fillStyle.GetColor() != null)
            {
                canvas.SetFillColor(_fillStyle.GetColor());
                canvas.FillEllipse(new Point(_frame.Left + _frame.Width / 2, _frame.Top + _frame.Height / 2), _frame.Width / 2, _frame.Height / 2);
            }
            if (_outlineStyle.IsEnabled().HasValue && _outlineStyle.IsEnabled().Value && _outlineStyle.GetColor() != null)
            {
                canvas.SetOutlineColor(_outlineStyle.GetColor());
                canvas.SetOutlineThickness(_outlineStyle.GetOutlineThickness() ?? 1);
                canvas.DrawEllipse(new Point(_frame.Left + _frame.Width / 2, _frame.Top + _frame.Height / 2), _frame.Width / 2, _frame.Height / 2);
            }
        }
    }
}
