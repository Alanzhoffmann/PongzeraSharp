using System.Numerics;
using PongzeraSharp.Interfaces;
using Raylib_cs;

namespace PongzeraSharp.Games.Snake
{
    internal class SnakeDot : IDraw
    {
        private const int Gap = 2;
        private Rectangle _originalRectangle;

        public SnakeDot(Rectangle rectangle)
        {
            Rectangle = rectangle;
        }

        public Rectangle Rectangle { get => _originalRectangle; set => _originalRectangle = value; }

        public void Draw()
        {
            var dot = new Rectangle(Rectangle.x + Gap, Rectangle.y + Gap, Rectangle.width - Gap * 2, Rectangle.height - Gap * 2);
            Raylib.DrawRectangleRec(dot, Color.BLACK);
        }

        public SnakeDot CreateCopy()
        {
            var newRectangle = new Rectangle(Rectangle.x, Rectangle.y, Rectangle.width, Rectangle.height);
            return new SnakeDot(newRectangle);
        }

        public void MoveTo(Vector2 vector)
        {
            _originalRectangle.y = vector.Y;
            _originalRectangle.x = vector.X;
        }

        public void Move(float x, float y)
        {
            _originalRectangle.y += y;
            _originalRectangle.x += x;
        }

        public bool IsPosition(Vector2 vector) => _originalRectangle.x == vector.X && _originalRectangle.y == vector.Y;
    }
}
