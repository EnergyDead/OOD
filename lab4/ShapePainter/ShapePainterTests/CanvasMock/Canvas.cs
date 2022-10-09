using ShapePainter.Canvas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapePainterTests.CanvasMock;

public class Canvas : ICanvas
{
    public List<Line> DrawnLines { get; private set; }
    public Ellipse DrawnEllipse { get; private set; }
    public Polygon DrawnPolygon { get; private set; }
    public Color Color { get; set; }

    public Canvas()
    {
        DrawnLines = new();
    }

    public void DrawEllipse(Point start, int width, int height)
    {
        DrawnEllipse = new Ellipse()
        {
            Color = Color,
            H = height,
            W = width,
            Start = start
        };
    }

    public void DrawLine(Point from, Point to)
    {
        DrawnLines.Add(new Line()
        {
            Color = Color,
            From = from,
            To = to
        });
    }

    public void DrawPolygon(Point[] points)
    {
        DrawnPolygon = new Polygon()
        {
            Color = Color,
            Points = points
        };
    }

    public void SavePicture(string fileName)
    {
        throw new NotImplementedException();
    }
}
public struct Line
{
    public Color Color;
    public Point From;
    public Point To;
}

public struct Ellipse
{
    public Color Color;
    public Point Start;
    public int W;
    public int H;
}

public struct Polygon
{
    public Color Color;
    public Point[] Points;
}
