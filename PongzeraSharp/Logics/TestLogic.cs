using PongzeraSharp.Drawables;
using Raylib_cs;

namespace PongzeraSharp.Logics
{
    public sealed class TestLogic : BaseLogic
    {
        private readonly Border _border = new();

        private readonly TimeSpan _timeToNewBall = TimeSpan.FromMilliseconds(300);
        private TimeSpan _elapsedTime = TimeSpan.Zero;
        private int _currentBallCount = 0;

        public TestLogic(GameWindow window) : base(window)
        {
        }

        public override IEnumerable<IDrawable> GetDrawables()
        {
            yield return _border;
            //yield return new MovingDot();
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            _elapsedTime += TimeSpan.FromSeconds(deltaTime);
            bool autoAddBall = false;

            if (_elapsedTime > _timeToNewBall)
            {
                _elapsedTime = TimeSpan.Zero;
                autoAddBall = true;
            }

            if (autoAddBall || Raylib.IsKeyPressed(KeyboardKey.KEY_A))
            {
                var ball = new BouncingDot(_border.Edges);

                Console.WriteLine($"Add new Bouncing dot! {ball}");
                ball.Init();
                Drawables.Add(ball);

                _currentBallCount++;
                Window.SetWindowTitle($"Current count: {_currentBallCount}");
            }
        }
    }
}
