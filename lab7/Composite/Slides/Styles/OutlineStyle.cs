using System.Drawing;

namespace Slides.Styles
{
    public class OutlineStyle : Style, IOutlineStyle
    {
        private uint? _thickness;
        public OutlineStyle()
        {
        }

        public OutlineStyle(Color color, bool isEnabled, uint thickness)
            : base(color, isEnabled)
        {
            _thickness = thickness;
        }

        public uint? GetOutlineThickness()
        {
            return _thickness;
        }

        public void SetOutlineThickness(uint thickness)
        {
            _thickness = thickness;
        }
    }
}
