using PongzeraSharp.Interfaces;
using Raylib_cs;

namespace PongzeraSharp.Drawables
{
    public class BouncingDot : IDraw, ILogic
    {
        private readonly Rectangle _limits;
        private Rectangle _dot;

        private float _speedVertical;
        private float _speedHorizontal;

        public BouncingDot(Rectangle limits)
        {
            _limits = limits;

            const float dotSize = 10;

            var positionHorizontal = _limits.GetCenterHorizontal() + (dotSize / 2);
            var positionVertical = _limits.GetCenterVertical() + (dotSize / 2);

            _dot = new Rectangle(positionHorizontal, positionVertical, dotSize, dotSize);

            _speedHorizontal = Random.Shared.NextSingle() * 300;
            _speedVertical = Random.Shared.NextSingle() * 300;

            var randomUp = Random.Shared.Next(2) > 0;
            var randomRight = Random.Shared.Next(2) > 0;

            if (randomUp)
            {
                InvertVerticalDirection();
            }

            if (randomRight)
            {
                InvertHorizontalDirection();
            }
        }

        private bool MovingLeft => _speedHorizontal < 0;
        private bool MovingUp => _speedVertical < 0;

        public void Draw()
        {
            Raylib.DrawRectangleRec(_dot, Color.BLACK);
        }

        public void Update(float deltaTime)
        {
            CalculateNewPosition(deltaTime);

            if (CheckHitAbove() || CheckHitBelow())
            {
                InvertVerticalDirection();
            }

            if (CheckHitLeft() || CheckHitRight())
            {
                InvertHorizontalDirection();
            }
        }

        public override string ToString()
        {
            return $"Hor speed: {_speedHorizontal}, Ver speed: {_speedVertical}";
        }

        private bool CheckHitLeft() => MovingLeft && _limits.GetBoundaryLeft() > _dot.GetBoundaryLeft();

        private bool CheckHitRight() => !MovingLeft && _limits.GetBoundaryRight() < _dot.GetBoundaryRight();

        private bool CheckHitAbove() => MovingUp && _limits.GetBoundaryUp() > _dot.GetBoundaryUp();

        private bool CheckHitBelow() => !MovingUp && _limits.GetBoundaryDown() < _dot.GetBoundaryDown();

        private void InvertVerticalDirection() => _speedVertical = -_speedVertical;

        private void InvertHorizontalDirection() => _speedHorizontal = -_speedHorizontal;

        private void CalculateNewPosition(float deltaTime)
        {
            _dot.x += _speedHorizontal * deltaTime;
            _dot.y += _speedVertical * deltaTime;
        }
    }
}
