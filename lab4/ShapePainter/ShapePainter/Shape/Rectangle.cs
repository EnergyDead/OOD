using ShapePainter.Canvas;
using System.Drawing;

namespace ShapePainter.Shape;

public class Rectangle : BaseShape
{
    private Point _point1;
    private Point _point2;

    public Point Point1 => _point1;
    public Point Point2 => _point2;

    public Rectangle(Color color,Point point1, Point point2)
    {
        Color = color;
        _point1 = point1;
        _point2 = point2;
    }

    public override void Draw(ICanvas canvas)
    {
        Point point3 = new Point(_point1.X, _point2.Y);
        Point point4 = new Point(_point2.X, _point1.Y);
        canvas.Color = Color;
        canvas.DrawLine(_point1, point3);
        canvas.DrawLine(point3, _point2);
        canvas.DrawLine(_point2, point4);
        canvas.DrawLine(point4, _point1);
    }
}
