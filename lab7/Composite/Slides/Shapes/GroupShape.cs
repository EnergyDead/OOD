using Slides.Shapes;
using Slides.Styles;
using System;
using System.Collections.Generic;

namespace Slides.Shapes
{
    public class GroupShape : IShape
    {
        private readonly List<IShape> _shapes;
        private readonly GroupStyle<IStyle> _fillStyle;
        private readonly GroupOutlineStyle _outlineStyle;

        public GroupShape()
        {
            _shapes = new List<IShape>();
            _fillStyle = new GroupStyle<IStyle>(GetGroupFillStyle());
            _outlineStyle = new GroupOutlineStyle(GetGroupOutlineStyle());
        }

        private IEnumerable<IOutlineStyle> GetGroupOutlineStyle()
        {
            foreach (var shape in _shapes)
            {
                yield return shape.GetOutlineStyle();
            }
        }

        private IEnumerable<IStyle> GetGroupFillStyle()
        {
            foreach (var shape in _shapes)
            {
                yield return shape.GetFillStyle();
            }
        }

        public IOutlineStyle GetOutlineStyle()
        {
            return _outlineStyle;
        }

        public IStyle GetFillStyle()
        {
            return _fillStyle;
        }

        public void Draw(ICanvas canvas)
        {
            foreach (var shape in _shapes)
            {
                shape.Draw(canvas);
            }
        }

        public void InsertShape(IShape shape, int position = 0)
        {
            if (position >= 0 && position <= ShapesCount)
            {
                _shapes.Insert(position, shape);
            }
        }

        public IShape GetShapeAtIndex(int index)
        {
            return IsIndexInRange(index) ? _shapes[index] : throw new IndexOutOfRangeException();
        }

        public void RemoveShapeAtIndex(int index)
        {
            if (IsIndexInRange(index))
            {
                _shapes.RemoveAt(index);
            }
        }

        public int ShapesCount => _shapes.Count;

        public Rect? Frame
        {
            get => GetFrame();
            set => SetFrame(value!.Value);
        }

        private bool IsIndexInRange(int index)
        {
            return index >= 0 && index < ShapesCount;
        }

        private void SetFrame(Rect frame)
        {
            if (frame.Height > 0 && frame.Width > 0)
            {
                if (ShapesCount > 0 && GetFrame().HasValue)
                {
                    var oldFrame = GetFrame().Value;
                    foreach (var shape in _shapes)
                    {
                        var shapeFrame = shape.Frame;
                        var newFrame = new Rect(
                            frame.Left + (shapeFrame.Value.Left - oldFrame.Left) * frame.Width / oldFrame.Width,
                            frame.Top + (shapeFrame.Value.Top - oldFrame.Top) * frame.Height / oldFrame.Height,
                            shapeFrame.Value.Width * frame.Width / oldFrame.Width,
                            shapeFrame.Value.Height * frame.Height / oldFrame.Height);
                        shape.Frame = newFrame;
                    }
                }
            }
            else
            {
                throw new ArgumentException("Frame height and width must be more than 0");
            }
        }

        private Rect? GetFrame()
        {
            if (ShapesCount <= 0)
            {
                return null;
            }

            double left = double.MaxValue;
            double top = double.MaxValue;
            double width = double.MinValue;
            double height = double.MinValue;

            foreach (var shape in _shapes)
            {
                var shapeFrame = shape.Frame.Value;
                left = Math.Min(left, shapeFrame.Left);
                top = Math.Min(top, shapeFrame.Top);
                width = Math.Max(width, shapeFrame.Width);
                height = Math.Max(height, shapeFrame.Height);
            }
            return new Rect(left, top, width - left, height - top);
        }
    }
}
