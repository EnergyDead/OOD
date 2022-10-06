using System.Drawing;

namespace ShapePainter.Canvas;

internal class Canvas : ICanvas, IDisposable
{
    private readonly string _png = ".png";
    private Color _color;
    private readonly Pen _pen;
    private Image _img;
    private Graphics _graphics;

    public Canvas()
    {
        _pen = new Pen(Color.Black);
        _img = new Bitmap(1000, 1000);
        _graphics = Graphics.FromImage(_img);
        UpdateCanvas();

    }

    public Color Color { get => _color; set => _color = value; }

    public void DrawEllipse(Point center, int width, int height)
    {
        _pen.Color = Color;
        _graphics.DrawEllipse(_pen, center.X, center.Y, width, height);
    }

    public void DrawLine(Point from, Point to)
    {
        _pen.Color = Color;
        _graphics.DrawLine(_pen, from, to);
    }

    public void SavePicture(string fileName)
    {
        _img.Save(fileName + _png);
        //UpdateCanvas();
    }

    private void UpdateCanvas()
    {
        _graphics.Clear(Color.White);
    }

    public void Dispose()
    {
    }
}
