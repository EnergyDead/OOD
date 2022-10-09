using ShapePainterTests.CanvasMock;
using Xunit;

namespace ShapePainterTests.ShapeTests;

public class TriangleTest
{
    [Fact]
    public void Draw()
    {
        // Arrange
        var canvasMock = new Canvas();
        var color = System.Drawing.Color.Red;
        System.Drawing.Point point1 = new System.Drawing.Point(10, 10);
        System.Drawing.Point point2 = new System.Drawing.Point(20, 10);
        System.Drawing.Point point3 = new System.Drawing.Point(30, 30);
        var line1 = new Line() { Color = color, From = point1, To = point2 };
        var line2 = new Line() { Color = color, From = point2, To = point3 };
        var line3 = new Line() { Color = color, From = point3, To = point1 };

        var triangle = new ShapePainter.Shape.Triangle(color, point1, point2, point3);

        // Act
        triangle.Draw(canvasMock);
        var drawnTriangle = canvasMock.DrawnLines;

        // Assert
        Assert.NotEmpty(drawnTriangle);
        Assert.Equal(3, drawnTriangle.Count);
        Assert.Equal(line1, drawnTriangle[0]);
        Assert.Equal(line2, drawnTriangle[1]);
        Assert.Equal(line3, drawnTriangle[2]);
    }
}
