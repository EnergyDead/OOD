using System.Drawing;
using Point = Slides.Shapes.Point;

namespace Slides
{
    public interface ICanvas
    {
        void SetOutlineColor(Color color);
        void SetFillColor(Color color);
        void SetOutlineThickness(uint thickness);
        void DrawLine(Point from, Point to);
        void DrawEllipse(Point center, double width, double height);
        void FillEllipse(Point center, double width, double height);
        void FillPolygon(List<Point> vertices);
    }
}