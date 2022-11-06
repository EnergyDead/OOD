using Slides.Styles;

namespace Slides.Shapes
{
    public abstract class Shape : IShape
    {
        protected Rect _frame;
        protected IOutlineStyle _outlineStyle;
        protected IStyle _fillStyle;

        public Rect? Frame { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Shape(Rect frame, IOutlineStyle outlineStyle = null, IStyle fillStyle = null)
        {
            _frame = frame;
            _outlineStyle = outlineStyle ?? new OutlineStyle();
            _fillStyle = fillStyle ?? new Style();
        }


        public virtual void Draw(ICanvas canvas)
        {
            throw new NotImplementedException();
        }

        public IStyle GetFillStyle()
        {
            throw new NotImplementedException();
        }

        public IOutlineStyle GetOutlineStyle()
        {
            throw new NotImplementedException();
        }
    }
}
