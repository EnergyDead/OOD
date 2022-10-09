using ShapePainterTests.CanvasMock;
using ShapePainter.Shape;
using Xunit;

namespace ShapePainterTests.ShapeTests;

public class EllipseTest
{
    [Fact]
    public void Draw()
    {
        // Arrange
        var canvasMock = new Canvas();
        var color = System.Drawing.Color.Red;
        var start = new System.Drawing.Point(10, 10);
        var ellipse = new ShapePainter.Shape.Ellipse(color, start, 10, 10);

        // Act
        ellipse.Draw(canvasMock);
        var drawnEllipse = canvasMock.DrawnEllipse;

        // Assert
        Assert.Equal(color, drawnEllipse.Color);
        Assert.Equal(start, drawnEllipse.Start);
        Assert.Equal(10, drawnEllipse.H);
        Assert.Equal(10, drawnEllipse.W);
    }
}
