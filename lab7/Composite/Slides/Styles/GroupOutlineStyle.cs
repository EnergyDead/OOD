using System.Collections.Generic;
using System.Linq;

namespace Slides.Styles
{
    public class GroupOutlineStyle : GroupStyle<IOutlineStyle>, IOutlineStyle
    {
        public GroupOutlineStyle(IEnumerable<IOutlineStyle> styles)
            : base(styles)
        {
        }
       
        public uint? GetOutlineThickness()
        {
            var firstThickness = Enumerable.First(_styles).GetOutlineThickness();
            foreach (var style in _styles)
            {
                if (style.GetOutlineThickness() != firstThickness)
                {
                    return null;
                }
            }
            return firstThickness;
        }

        public void SetOutlineThickness(uint thickness)
        {
            foreach (var style in _styles)
            {
                style.SetOutlineThickness(thickness);
            }
        }
    }
}
