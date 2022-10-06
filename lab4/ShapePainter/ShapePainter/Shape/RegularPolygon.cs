using ShapePainter.Canvas;
using System.Drawing;

namespace ShapePainter.Shape;

internal class RegularPolygon : BaseShape
{
    private Point _startPos;
    private int _vertexCount;
    private int _radius;

    public RegularPolygon(Color color, Point startPos, int vertexCount, int radius)
    {
        Color = color;
        _startPos = startPos;
        _vertexCount = vertexCount;
        _radius = radius;
    }

    public override void Draw(ICanvas canvas)
    {
        throw new NotImplementedException();
    }
}
