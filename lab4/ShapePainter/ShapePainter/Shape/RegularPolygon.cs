using ShapePainter.Canvas;
using System.Drawing;

namespace ShapePainter.Shape;

public class RegularPolygon : BaseShape
{
    private Point[] _points;
    public Point[] Points => _points;

    public RegularPolygon(Color color, Point[] points)
    {
        Color = color;
        _points = points;
    }

    public override void Draw(ICanvas canvas)
    {
        canvas.Color = Color;
        canvas.DrawPolygon(_points);
    }
}
