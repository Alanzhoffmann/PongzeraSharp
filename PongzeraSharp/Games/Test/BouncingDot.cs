using PongzeraSharp.Interfaces;
using Raylib_cs;

namespace PongzeraSharp.Games.Test
{
    public class BouncingDot : IDraw, ILogic
    {
        private readonly Rectangle _limits;
        private readonly BouncingLogic _bouncingLogic;
        private Rectangle _dot;

        public BouncingDot(Rectangle limits)
        {
            _limits = limits;

            const float dotSize = 10;

            var positionHorizontal = _limits.GetCenterHorizontal() + dotSize / 2;
            var positionVertical = _limits.GetCenterVertical() + dotSize / 2;

            _dot = new Rectangle(positionHorizontal, positionVertical, dotSize, dotSize);

            var speedHorizontal = Random.Shared.NextSingle() * 600;
            var speedVertical = Random.Shared.NextSingle() * 600;

            _bouncingLogic = new BouncingLogic(speedHorizontal, speedVertical, positionHorizontal, positionVertical);

            var randomUp = Random.Shared.Next(2) > 0;
            var randomRight = Random.Shared.Next(2) > 0;

            if (randomUp)
            {
                _bouncingLogic.InvertVerticalDirection();
            }

            if (randomRight)
            {
                _bouncingLogic.InvertHorizontalDirection();
            }
        }

        public void Draw()
        {
            Raylib.DrawRectangleRec(_dot, Color.BLACK);
        }

        public void Update(float deltaTime)
        {
            _bouncingLogic.Update(deltaTime);

            if (CheckHitAbove() || CheckHitBelow())
            {
                _bouncingLogic.InvertVerticalDirection();
            }

            if (CheckHitLeft() || CheckHitRight())
            {
                _bouncingLogic.InvertHorizontalDirection();
            }

            _dot.x = _bouncingLogic.PositionX;
            _dot.y = _bouncingLogic.PositionY;
        }

        public override string ToString()
        {
            return _bouncingLogic.ToString();
        }

        private bool CheckHitLeft() => _bouncingLogic.MovingLeft && _limits.GetBoundaryLeft() > _dot.GetBoundaryLeft();

        private bool CheckHitRight() => !_bouncingLogic.MovingLeft && _limits.GetBoundaryRight() < _dot.GetBoundaryRight();

        private bool CheckHitAbove() => _bouncingLogic.MovingUp && _limits.GetBoundaryUp() > _dot.GetBoundaryUp();

        private bool CheckHitBelow() => !_bouncingLogic.MovingUp && _limits.GetBoundaryDown() < _dot.GetBoundaryDown();
    }
}
