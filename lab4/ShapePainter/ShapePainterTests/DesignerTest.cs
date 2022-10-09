using System.Collections.Generic;
using ShapePainter.Designer;
using ShapePainter.Shape;
using Xunit;

namespace ShapePainterTests;

public class DesignerTest
{
    [Fact]
    public void CreateDraft()
    {
        // Arrange
        string ellipse = "ellipse red 10 10 50 50";
        string rectangle = "rectangle black 20 20 30 30";
        string errorDesc = "rectangleblack20 20 30 30";
        List<string> descriptions = new() { ellipse, rectangle, errorDesc };

        IShapeFactory shapeFactory = new ShapeFactory();
        var designer = new Designer(shapeFactory);

        // Act
        var pictureDraft = designer.CreateDraft(descriptions); 
        var shapes = pictureDraft.Shapes;

        // Assert
        Assert.NotNull(pictureDraft);
        Assert.NotEmpty(shapes);
        Assert.Equal(2, shapes.Count);
        Assert.Equal(typeof(Ellipse), shapes[0].GetType());
        Assert.Equal(typeof(Rectangle), shapes[1].GetType());
    }
}
