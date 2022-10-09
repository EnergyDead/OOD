using ShapePainter.Canvas;
using System.Drawing;

namespace ShapePainter.Shape;

public abstract class BaseShape
{
    public abstract void Draw(ICanvas canvas);
    public Color Color { get; set; }
}