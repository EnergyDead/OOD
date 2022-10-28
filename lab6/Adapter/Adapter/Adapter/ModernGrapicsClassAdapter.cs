using Adapter.GraphicsLib;
using Adapter.ModernGrapicsLib;
using System.Drawing;
using Point = Adapter.ModernGrapicsLib.Point;

namespace Adapter.Adapter;

public class ModernGrapicsClassAdapter : ModernGraphicsRenderer, ICanvas
{
    private Point _startPoint = new(0, 0);
    private Color _color = Color.FromArgb(0, 0, 0, 0);

    public ModernGrapicsClassAdapter(TextWriter output) : base(output)
    {
    }

    public void LineTo(int x, int y)
    {
        Point newPosition = new(x, y);
        DrawLine(_startPoint, newPosition, _color);
        _startPoint = newPosition;
    }

    public void MoveTo(int x, int y)
    {
        _startPoint = new Point(x, y);
    }

    public void SetColor(uint rgbColor)
    {
        _color = Color.FromArgb((int)rgbColor);
    }
}
