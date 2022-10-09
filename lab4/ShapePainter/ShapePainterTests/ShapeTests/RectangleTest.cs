using ShapePainterTests.CanvasMock;
using Xunit;

namespace ShapePainterTests.ShapeTests;

public class RectangleTest
{
    [Fact]
    public void Draw()
    {
        // Arrange
        var canvasMock = new Canvas();
        var color = System.Drawing.Color.Red;
        var p1 = new System.Drawing.Point(10, 10);
        var p2 = new System.Drawing.Point(10, 20);
        var p3 = new System.Drawing.Point(20, 20);
        var p4 = new System.Drawing.Point(20, 10);
        var line1 = new Line() { Color = color, From = p1, To = p2 };
        var line2 = new Line() { Color = color, From = p2, To = p3 };
        var line3 = new Line() { Color = color, From = p3, To = p4 };
        var line4 = new Line() { Color = color, From = p4, To = p1 };

        var rectangle = new ShapePainter.Shape.Rectangle(color, p1, p3);

        // Act
        rectangle.Draw(canvasMock);
        var drawnRectangle = canvasMock.DrawnLines;

        // Assert
        Assert.NotEmpty(drawnRectangle);
        Assert.Equal(4, drawnRectangle.Count);
        Assert.Equal(line1, drawnRectangle[0]);
        Assert.Equal(line2, drawnRectangle[1]);
        Assert.Equal(line3, drawnRectangle[2]);
        Assert.Equal(line4, drawnRectangle[3]);        
    }
}
