using Slides;
using Slides.Shapes;
using Slides.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SlidesUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Drawing();
        }
        private void Drawing()
        {
            var wpfCanvas = (System.Windows.Controls.Canvas)FindName("canvas");
            ICanvas canvas = new Canvas(wpfCanvas);
            var slide = new Slide(1000, 700, System.Drawing.Color.Gray);

            var grassFrame = new Slides.Shapes.Rect(0, 500, 1000, 200);
            var grassFillStyle = new Slides.Styles.Style(System.Drawing.Color.Green, true);
            var grass = new Slides.Shapes.Rectangle(grassFrame, null, grassFillStyle);

            var lakeFrame = new Slides.Shapes.Rect(600, 500, 300, 100);
            var lakeFillStyle = new Slides.Styles.Style(System.Drawing.Color.BlueViolet, true);
            var lakeOutlineStyle = new OutlineStyle(System.Drawing.Color.Blue, true, 2);
            var lake = new Slides.Shapes.Ellipse(lakeFrame, lakeOutlineStyle, lakeFillStyle);

            var house = new GroupShape();

            var baseFrame = new Slides.Shapes.Rect(100, 400, 300, 200);
            var baseFillStyle = new Slides.Styles.Style(System.Drawing.Color.Orange, true);
            var baseOutlineStyle = new OutlineStyle(System.Drawing.Color.OrangeRed, true, 2);
            var baseShape = new Slides.Shapes.Rectangle(baseFrame, baseOutlineStyle, baseFillStyle);

            var roofFrame = new Slides.Shapes.Rect(50, 300, 400, 100);
            var roofFillStyle = new Slides.Styles.Style(System.Drawing.Color.ForestGreen, true);
            var roof = new Slides.Shapes.Triangle(roofFrame, null, roofFillStyle);

            var pipeFrame = new Slides.Shapes.Rect(330, 300, 50, 90);
            var pipeFillStyle = new Slides.Styles.Style(System.Drawing.Color.Salmon, true);
            var pipeOutlineStyle = new OutlineStyle(System.Drawing.Color.Sienna, true, 2);
            var pipe = new Slides.Shapes.Rectangle(pipeFrame, pipeOutlineStyle, pipeFillStyle);

            house.InsertShape(baseShape, 0);
            house.InsertShape(pipe, 1);
            house.InsertShape(roof, 2);

            slide.InsertShape(grass);
            slide.InsertShape(lake, 1);
            slide.InsertShape(house, 2);
            slide.Draw(canvas);
        }
    }
}
