using ShapePainter.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShapePainterTests;

public class ShapeFactoryTest
{
    private readonly IShapeFactory shapeFactory;
    public ShapeFactoryTest()
    {
        shapeFactory = new ShapeFactory();
    }

    [Fact]
    public void CreateShape_EllipseDescription_CorrectShape()
    {
        // Arrange
        string description = "ellipse green 10 10 50 50";
        System.Drawing.Point start = new System.Drawing.Point(10, 10);

        // Act
        BaseShape shape = shapeFactory.CreateShape(description);
        Ellipse? ellipse = shape as Ellipse;

        // Assert
        Assert.NotNull(ellipse);
        Assert.Equal(System.Drawing.Color.Green, ellipse!.Color);
        Assert.Equal(start, ellipse!.Start);
        Assert.Equal(50, ellipse!.Width);
        Assert.Equal(50, ellipse!.Height);
    }

    [Fact]
    public void CreateShape_RectangleDescription_CorrectShape()
    {
        // Arrange
        string description = "Rectangle green 10 10 50 50";
        System.Drawing.Point p1 = new System.Drawing.Point(10, 10);
        System.Drawing.Point p2 = new System.Drawing.Point(50, 50);

        // Act
        BaseShape shape = shapeFactory.CreateShape(description);
        Rectangle? rectangle = shape as Rectangle;

        // Assert
        Assert.NotNull(rectangle);
        Assert.Equal(System.Drawing.Color.Green, rectangle!.Color);
        Assert.Equal(p1, rectangle!.Point1);
        Assert.Equal(p2, rectangle!.Point2);
    }

    [Fact]
    public void CreateShape_RegularPolygonDescription_CorrectShape()
    {
        // Arrange
        string description = "RegularPolygon green 10 10 50 50";
        System.Drawing.Point p1 = new System.Drawing.Point(10, 10);
        System.Drawing.Point p2 = new System.Drawing.Point(50, 50);

        // Act
        BaseShape shape = shapeFactory.CreateShape(description);
        RegularPolygon? regularPolygon = shape as RegularPolygon;

        // Assert
        Assert.NotNull(regularPolygon);
        Assert.Equal(System.Drawing.Color.Green, regularPolygon!.Color);
        Assert.Contains( regularPolygon.Points, p => p == p1);
        Assert.Contains( regularPolygon.Points, p => p == p2);
    }

    [Fact]
    public void CreateShape_TriangleDescription_CorrectShape()
    {
        // Arrange
        string description = "Triangle green 10 10 50 50 20 20";
        System.Drawing.Point p1 = new System.Drawing.Point(10, 10);
        System.Drawing.Point p2 = new System.Drawing.Point(50, 50);
        System.Drawing.Point p3 = new System.Drawing.Point(20, 20);

        // Act
        BaseShape shape = shapeFactory.CreateShape(description);
        Triangle? triangle = shape as Triangle;

        // Assert
        Assert.NotNull(triangle);
        Assert.Equal(System.Drawing.Color.Green, triangle!.Color);
        Assert.Equal(p1, triangle!.Vertex1);
        Assert.Equal(p2, triangle!.Vertex2);
        Assert.Equal(p3, triangle!.Vertex3);
    }
}
