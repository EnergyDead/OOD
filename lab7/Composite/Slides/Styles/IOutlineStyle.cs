namespace Slides.Styles
{
    public interface IOutlineStyle : IStyle
    {
        void SetOutlineThickness(uint thickness);
        uint? GetOutlineThickness();
    }
}
