using Slides.Shapes;
using System.Drawing;

namespace Slides.Styles
{
    public class Style : IStyle
    {
        private Color _color;
        private bool _isEnabled;

        public Style()
        {
        }

        public Style(Color color, bool isEnabled)
        {
            _color = color;
            _isEnabled = isEnabled;
        }

        public void Enable(bool enable)
        {
            _isEnabled = enable;
        }

        public Color GetColor()
        {
            return _color;
        }

        public bool? IsEnabled()
        {
            return _isEnabled;
        }

        public void SetColor(Color color)
        {
            _color = color;
        }
    }
}
