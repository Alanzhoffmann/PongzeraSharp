using PongzeraSharp.Drawables;
using PongzeraSharp.Logics;
using Raylib_cs;

namespace PongzeraSharp.Games.Test
{
    public sealed class TestGame : BaseGame
    {
        private readonly Border _border;
        private readonly ElapsedLogic _addBallEvent;
        private int _currentBallCount = 0;

        public TestGame(GameWindow window) : base(window)
        {
            _border = new(window);
            _addBallEvent = new ElapsedLogic(AddBall, TimeSpan.FromMilliseconds(50), () => Raylib.IsKeyPressed(KeyboardKey.KEY_A));
        }

        public override void Init()
        {
            base.Init();

            AddGameObject(_border);
            AddGameObject(_addBallEvent);
        }

        private void AddBall()
        {
            var ball = new BouncingDot(_border.Edges);

            Console.WriteLine($"Add new Bouncing dot! {ball}");
            AddGameObject(ball);

            _currentBallCount++;
            Window.SetWindowTitle($"Current count: {_currentBallCount}");
        }
    }
}
