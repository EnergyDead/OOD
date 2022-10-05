using System.Drawing;

namespace ShapePainter.Canvas;

internal class Canvas : ICanvas
{
    private readonly string _png = ".png";
    private readonly Pen _pen;
    private Image _img;

    public Canvas()
    {
        _img = GetNewCanvas();
        _pen = new Pen(Color.White);

    }

    private Color _color;
    public Color Color { get => _color; set => _color = value; }

    public void DrawEllipse(Point center, int width, int height)
    {
        using (Graphics g = Graphics.FromImage(_img))
        {
            _pen.Color = Color;
            g.DrawEllipse(_pen, center.X, center.Y, width, height);
        }
    }

    public void DrawLine(Point from, Point to)
    {
        using (Graphics g = Graphics.FromImage(_img))
        {
            _pen.Color = Color;
            g.DrawLine(_pen, from, to);
        }
    }

    public void SavePicture(string fileName)
    {
        _img.Save(fileName + _png);
        _img = GetNewCanvas();
    }
    private Bitmap GetNewCanvas()
    {
        return new Bitmap(1000, 1000);
    }
}
