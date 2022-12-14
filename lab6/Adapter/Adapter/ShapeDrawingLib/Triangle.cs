using Adapter.GraphicsLib;

namespace Adapter.ShapeDrawingLib;

internal class Triangle : ICanvasDrawable
{
    private readonly Point _vertex1;
    private readonly Point _vertex2;
    private readonly Point _vertex3;
    private readonly uint _rgbColor;

    public Triangle(Point v1, Point v2, Point v3, uint rgbColor)
    {
        _vertex1 = v1;
        _vertex2 = v2;
        _vertex3 = v3;
        _rgbColor = rgbColor;
    }

    public void Draw(ICanvas canvas)
    {
        canvas.SetColor(_rgbColor);
        canvas.MoveTo(_vertex1.X, _vertex1.Y);

        canvas.LineTo(_vertex2.X, _vertex2.Y);
        canvas.LineTo(_vertex3.X, _vertex3.Y);
        canvas.LineTo(_vertex1.X, _vertex1.Y);
    }
}
