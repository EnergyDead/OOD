using System.Drawing;

namespace ShapePainter.Canvas;

internal class Canvas : ICanvas, IDisposable
{
    private readonly string _png = ".png";
    private Color _color = Color.Black;
    private readonly Pen _pen;
    private Image _img;
    private Graphics _graphics;

    public Canvas()
    {
        _pen = new Pen(_color);
        _img = new Bitmap(1000, 1000);
        _graphics = Graphics.FromImage(_img);
        UpdateCanvas();

    }

    public Color Color { get => _color; set => _color = value; }

    public void DrawEllipse(Point start, int width, int height)
    {
        try
        {
            _pen.Color = Color;
            _graphics.DrawEllipse(_pen, start.X, start.Y, width, height);
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }

    public void DrawLine(Point from, Point to)
    {
        try
        {
            _pen.Color = Color;
            _graphics.DrawLine(_pen, from, to);
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }

    public void DrawPolygon(Point[] points)
    {
        try
        {
            _graphics.DrawPolygon(_pen, points);
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }

    public void SavePicture(string fileName)
    {
        _img.Save(fileName + _png);
        UpdateCanvas();
    }

    private void UpdateCanvas()
    {
        _graphics.Clear(Color.White);
    }

    private void ResetPen()
    {
        Color = Color.Black;
        _pen.Color = Color;
    }

    public void Dispose()
    {
    }
}
