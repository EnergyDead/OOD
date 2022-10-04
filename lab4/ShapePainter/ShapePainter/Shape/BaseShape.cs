using ShapePainter.Canvas;

namespace ShapePainter.Shape;

internal abstract class BaseShape
{
    public abstract void Draw(ICanvas canvas);
    public ColorType Color { get; set; }
}