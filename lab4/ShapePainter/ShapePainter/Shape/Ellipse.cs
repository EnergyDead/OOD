using ShapePainter.Canvas;
using System.Drawing;

namespace ShapePainter.Shape;

internal class Ellipse : BaseShape
{
    private Point _startPos;
    private int _width;
    private int _height;

    public Ellipse(Color color, Point startPos, int width, int height)
    {
        Color = color;
        _startPos = startPos;
        _width = width;
        _height = height;
    }

    public override void Draw(ICanvas canvas)
    {
        throw new NotImplementedException();
    }
}
