using ShapePainter.Canvas;
using System.Drawing;

namespace ShapePainter.Shape;

internal class Triangle : BaseShape
{
    private Point _vertex1;
    private Point _vertex2;
    private Point _vertex3;

    public Triangle(Color color, Point vertex1, Point vertex2, Point vertex3)
    {
        Color = color;
        _vertex1 = vertex1;
        _vertex2 = vertex2;
        _vertex3 = vertex3;
    }

    public override void Draw(ICanvas canvas)
    {
        canvas.Color = Color;
        canvas.DrawLine(_vertex1, _vertex2);
        canvas.DrawLine(_vertex2, _vertex3);
        canvas.DrawLine(_vertex3, _vertex1);
    }
}
