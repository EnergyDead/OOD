using ShapePainterTests.CanvasMock;
using Xunit;

namespace ShapePainterTests.ShapeTests;

public class RegularPolygonTest
{
    [Fact]
    public void Draw()
    {
        // Arrange
        var canvasMock = new Canvas();
        var color = System.Drawing.Color.Red;
        System.Drawing.Point[] points = new System.Drawing.Point[] 
        {
            new System.Drawing.Point(10, 10),
            new System.Drawing.Point(20, 20),
            new System.Drawing.Point(30, 30)
        };

        var regularPolygon = new ShapePainter.Shape.RegularPolygon(color, points);

        // Act
        regularPolygon.Draw(canvasMock);
        var drawnregularPolygon = canvasMock.DrawnPolygon;

        // Assert
        Assert.Equal(color, drawnregularPolygon.Color);
        Assert.Equal(points, drawnregularPolygon.Points);
    }
}
