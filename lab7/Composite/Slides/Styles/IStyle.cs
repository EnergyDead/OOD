using System.Drawing;

namespace Slides.Styles
{
    public interface IStyle
    {
        bool? IsEnabled();
        void Enable(bool enable);
        Color GetColor();
        void SetColor(Color color);
    }
}
