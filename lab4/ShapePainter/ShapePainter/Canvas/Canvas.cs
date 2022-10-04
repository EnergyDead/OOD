﻿using System.Drawing;

namespace ShapePainter.Canvas;

internal class Canvas : ICanvas
{
    private readonly string _png = ".png";
    private readonly Image _img;
    private readonly Pen _pen;

    public Canvas()
    {
        _img = new Bitmap(1000, 1000);
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
    }
}