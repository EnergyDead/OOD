using Slides.Styles;

namespace Slides.Shapes
{
    public interface IShape : IDrawable
    {
        Rect? Frame { get; set; }
        IStyle GetFillStyle();
        IOutlineStyle GetOutlineStyle();
    }
}
