using System.Drawing;

namespace ShapePainter.Canvas;

internal interface ICanvas
{
    Color Color { set; }
    void DrawLine(Point from, Point to);
    void DrawEllipse(Point start, int width, int height);
    void DrawPolygon(Point[] points);
    void SavePicture(string fileName);
}
