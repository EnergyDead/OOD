using Slides;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media;
using Point = Slides.Shapes.Point;
using Color = System.Drawing.Color;
using System.Windows.Shapes;
using System.Linq;

namespace SlidesUI
{
    internal class Canvas : ICanvas
    {
        private readonly System.Windows.Controls.Canvas _canvas;
        private SolidColorBrush _outlineColor;
        private SolidColorBrush _fillColor;
        private uint _thickness;

        public Canvas(System.Windows.Controls.Canvas canvas)
        {
            _canvas = canvas;
            _fillColor = new SolidColorBrush(Colors.Transparent);
            _outlineColor = new SolidColorBrush(Colors.Black);
            _thickness = 1;
        }

        public void DrawEllipse(Point center, double width, double height)
        {
            var ellipse = new System.Windows.Shapes.Ellipse
            {
                Width = width,
                Height = height,
                Stroke = _outlineColor,
            };
            System.Windows.Controls.Canvas.SetLeft(ellipse, center.X - width / 2);
            System.Windows.Controls.Canvas.SetTop(ellipse, center.Y - height / 2);
            _canvas.Children.Add(ellipse);
        }

        public void DrawLine(Point from, Point to)
        {
            var line = new Line
            {
                X1 = from.X,
                Y1 = from.Y,
                X2 = to.X,
                Y2 = to.Y,
                Stroke = _outlineColor,
                StrokeThickness = _thickness
            };
            _canvas.Children.Add(line);
        }

        public void FillEllipse(Point center, double width, double height)
        {
            var ellipse = new System.Windows.Shapes.Ellipse
            {
                Width = width,
                Height = height,
                Stroke = _outlineColor,
            };
            System.Windows.Controls.Canvas.SetLeft(ellipse, center.X - width / 2);
            System.Windows.Controls.Canvas.SetTop(ellipse, center.Y - height / 2);
            _canvas.Children.Add(ellipse);
        }

        public void FillPolygon(List<Point> vertices)
        {
            var polygon = new Polygon
            {
                Points = new PointCollection(vertices.Select(point => new System.Windows.Point(point.X, point.Y))),
                Fill = _fillColor
            };
            _canvas.Children.Add(polygon);
        }

        public void SetFillColor(Color color)
        {
            var color1 = new System.Windows.Media.Color
            {
                R = color.R,
                G = color.G,
                B = color.B,
                A = color.A
            };
            _fillColor = new SolidColorBrush(color1);
        }

        public void SetOutlineColor(Color color)
        {
            var color1 = new System.Windows.Media.Color
            {
                R = color.R,
                G = color.G,
                B = color.B,
                A = color.A
            };
            _outlineColor = new SolidColorBrush(color1);
        }

        public void SetOutlineThickness(uint thickness)
        {
            _thickness = thickness;
        }
    }
}