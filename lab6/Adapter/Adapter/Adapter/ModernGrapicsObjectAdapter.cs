using Adapter.GraphicsLib;
using Adapter.ModernGrapicsLib;
using System.Drawing;
using Point = Adapter.ModernGrapicsLib.Point;

namespace Adapter.Adapter;

public class ModernGrapicsObjectAdapter : ICanvas
{
    private readonly ModernGraphicsRenderer _renderer;
    private Point _startPoint = new(0, 0);
    private RGBAColor _color = new(0, 0, 0, 0);

    public ModernGrapicsObjectAdapter(ModernGraphicsRenderer renderer)
    {
        _renderer = renderer ?? throw new NullReferenceException(nameof(renderer));
    }

    public void LineTo(int x, int y)
    {
        Point newPosition = new(x, y);
        _renderer.DrawLine(_startPoint, newPosition, _color);
        _startPoint = newPosition;
    }

    public void MoveTo(int x, int y)
    {
        _startPoint = new Point(x, y);
    }

    public void SetColor(uint rgbColor)
    {
        var color = Color.FromArgb((int)rgbColor);
        _color = new RGBAColor(color.R.ToFloat(), color.G.ToFloat(), color.B.ToFloat(), 1);
    }

    public void BeginDraw()
    {
        _renderer.BeginDraw();
    }

    public void EndDraw()
    {
        _renderer.EndDraw();
    }
}