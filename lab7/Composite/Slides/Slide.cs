using Slides.Shapes;
using System.Drawing;
using Point = Slides.Shapes.Point;

namespace Slides
{
    public class Slide
    {
        public readonly double _width;
        public readonly double _height;
        public Color _background;
        private readonly List<IShape> _shapes;

        public Slide(double w, double h, Color color)
        {
            _width = w;
            _height = h;
            _background = color;
            _shapes = new List<IShape>();
        }

        public int Count => _shapes.Count;
        public double Width => _width;
        public double Heigth => _height;
        public Color Background
        {
            get => _background;
            set => _background = value;
        }


        public void Draw(ICanvas canvas)
        {
            SetBackground(canvas);
            foreach (var shape in _shapes)
            {
                shape.Draw(canvas);
            }
        }
        public IShape GetShapeAtIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            return _shapes[index];
        }
        public void InsertShape(IShape shape, int index = 0)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            _shapes.Insert(index, shape);
        }

        public void RemoveShape(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
            _shapes.RemoveAt(index);
        }

        private void SetBackground(ICanvas canvas)
        {
            canvas.SetFillColor(_background);

            var points = new List<Point>
            {
                new Point(0, 0),
                new Point(0, _height),
                new Point(_width, _height),
                new Point(_width, 0)
            };
            canvas.FillPolygon(points);
        }

    }
}
