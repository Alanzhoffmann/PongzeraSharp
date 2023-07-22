using System.Numerics;
using PongzeraSharp.Drawables;
using PongzeraSharp.Interfaces;
using PongzeraSharp.Logics;
using Raylib_cs;

namespace PongzeraSharp.Games.Snake
{
    internal class SnakePlayer : IDraw, ILogic
    {
        public const int StartSize = 20;

        public static readonly Vector2 _pixels = new(40, 30);
        private readonly Border _border;
        private readonly Vector2 _size;
        private readonly ElapsedLogic _elapsedMovement;

        private readonly TimeSpan _refreshRate = TimeSpan.FromSeconds(1) / 20;
        private Direction _lastDirection = Direction.Right;
        private bool _directionChanged = false;

        public SnakePlayer(Border border)
        {
            _border = border;
            _size = new(_border.Edges.width / _pixels.X, _border.Edges.height / _pixels.Y);

            _elapsedMovement = new ElapsedLogic(RunMovement, _refreshRate);

            IncreaseSize(StartSize);
        }

        private enum Direction
        {
            Left,
            Up,
            Right,
            Down
        }

        public List<SnakeDot> Dots { get; } = new List<SnakeDot>();

        public void Draw()
        {
            foreach (var dot in Dots)
            {
                dot.Draw();
            }
        }

        public void Update(float deltaTime)
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT) && _lastDirection != Direction.Right && !_directionChanged)
            {
                _directionChanged = true;
                _lastDirection = Direction.Left;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) && _lastDirection != Direction.Left && !_directionChanged)
            {
                _directionChanged = true;
                _lastDirection = Direction.Right;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP) && _lastDirection != Direction.Down && !_directionChanged)
            {
                _directionChanged = true;
                _lastDirection = Direction.Up;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN) && _lastDirection != Direction.Up && !_directionChanged)
            {
                _directionChanged = true;
                _lastDirection = Direction.Down;
            }

            _elapsedMovement.Update(deltaTime);
        }

        private void RunMovement()
        {
            Vector2? lastPosition = null;
            foreach (var dot in Dots)
            {
                if (lastPosition.HasValue)
                {
                    if (dot.IsPosition(lastPosition.Value))
                    {
                        return;
                    }

                    var currentLastPosition = new Vector2(dot.Rectangle.x, dot.Rectangle.y);
                    dot.MoveTo(lastPosition.Value);
                    lastPosition = currentLastPosition;

                    continue;
                }

                lastPosition = new Vector2(dot.Rectangle.x, dot.Rectangle.y);

                // First dot
                switch (_lastDirection)
                {
                    case Direction.Left:
                        dot.Move(-_size.X, 0);
                        break;
                    case Direction.Up:
                        dot.Move(0, -_size.Y);
                        break;
                    case Direction.Right:
                        dot.Move(_size.X, 0);
                        break;
                    case Direction.Down:
                        dot.Move(0, _size.Y);
                        break;
                }
            }

            _directionChanged = false;
        }

        private void IncreaseSize(int quantity = 1)
        {
            for (int i = 0; i < quantity; i++)
            {
                var newDot = CreateDot();
                Dots.Add(newDot);
            }
        }

        private SnakeDot CreateDot()
        {
            var rectangle = new Rectangle(0, 0, _size.X, _size.Y);

            if (Dots.Count == 0)
            {
                rectangle.x = _size.X * _pixels.X / 2;
                rectangle.y = _size.Y * _pixels.Y / 2;

                return new SnakeDot(rectangle);
            }

            var lastDot = Dots.Last();
            return lastDot.CreateCopy();
        }
    }
}
