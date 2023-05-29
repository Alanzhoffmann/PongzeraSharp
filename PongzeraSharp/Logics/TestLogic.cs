using PongzeraSharp.Drawables;
using Raylib_cs;

namespace PongzeraSharp.Logics
{
    public sealed class TestLogic : BaseLogic
    {
        private readonly Border _border = new();

        public TestLogic(GameWindow window) : base(window)
        {
        }

        public override IEnumerable<IDrawable> GetDrawables()
        {
            yield return _border;
            yield return new MovingDot();
            yield return new BouncingDot(_border.Edges);
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_A))
            {
                var ball = new BouncingDot(_border.Edges);

                Console.WriteLine($"Add new Bouncing dot! {ball}");
                ball.Init();
                Drawables.Add(ball);
            }
        }
    }
}
