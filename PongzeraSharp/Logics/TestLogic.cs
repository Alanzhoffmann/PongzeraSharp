using PongzeraSharp.Drawables;
using Raylib_cs;

namespace PongzeraSharp.Logics
{
    public sealed class TestLogic : BaseLogic
    {
        private readonly Border _border;

        private readonly TimeSpan _timeToNewBall = TimeSpan.FromMilliseconds(300);
        private TimeSpan _elapsedTime = TimeSpan.Zero;
        private int _currentBallCount = 0;

        public TestLogic(GameWindow window) : base(window)
        {
            _border = new(window);
        }

        public override void Init()
        {
            base.Init();

            AddGameObject(_border);
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
                AddGameObject(ball);

                _currentBallCount++;
                Window.SetWindowTitle($"Current count: {_currentBallCount}");
            }
        }
    }
}
