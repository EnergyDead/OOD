using System.Drawing;

namespace Adapter.ModernGrapicsLib;

public class ModernGraphicsRenderer : IDisposable
{
    private readonly TextWriter _output;
    private bool _drawing = false;

    public ModernGraphicsRenderer(TextWriter output)
    {
        _output = output ?? throw new NullReferenceException(nameof(output));
    }

    public void BeginDraw()
    {
        if (_drawing)
        {
            throw new GraphicsLogicalException("Drawing has already begun");
        }

        _output.WriteLine("<draw>");
        _drawing = true;
    }

    public void DrawLine(Point start, Point end, Color color)
    {
        if (!_drawing)
        {
            throw new GraphicsLogicalException("DrawLine is allowed between BeginDraw()/EndDraw() only");
        }

        _output.WriteLine($"<line fromX={start.X} fromY={start.Y} toX={end.X} toY={end.Y}>");
        _output.WriteLine($"  <color r=\"{color.R}\" g=\"{color.G}\" b=\"{color.B}\" a=\"{color.A}\" />");
        _output.WriteLine("</line>");
    }

    public void EndDraw()
    {
        if (!_drawing)
        {
            throw new GraphicsLogicalException("Drawing has not been started");
        }

        _output.WriteLine("</draw>");
        _drawing = false;
    }

    public void Dispose()
    {
        if (_drawing) // Завершаем рисование, если оно было начато
        {
            EndDraw();
        }
    }
}
