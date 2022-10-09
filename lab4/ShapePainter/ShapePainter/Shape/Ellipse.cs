using ShapePainter.Canvas;
using System.Drawing;

namespace ShapePainter.Shape;

public class Ellipse : BaseShape
{
    private Point _start;
    private int _width;
    private int _height;

    public Point Start => _start;
    public int Width => _width;
    public int Height => _height;

    public Ellipse(Color color, Point start, int width, int height)
    {
        Color = color;
        _start = start;
        _width = width;
        _height = height;
    }

    public override void Draw(ICanvas canvas)
    {
        canvas.Color = Color;
        canvas.DrawEllipse(_start, _width, _height);
    }
}
