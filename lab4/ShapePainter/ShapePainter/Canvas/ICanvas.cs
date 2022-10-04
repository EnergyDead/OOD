using System.Drawing;

namespace ShapePainter.Canvas;

internal interface ICanvas
{
    Color Color { set; }
    void DrawLine(Point from, Point to);
    void DrawEllipse(Point center, int width, int height);
    void SavePicture(string fileName);
}
