using PongzeraSharp.Drawables;
using Raylib_cs;

namespace PongzeraSharp.Logics
{
    public sealed class TestLogic : BaseLogic
    {
        readonly Border _border = new();

        public override IEnumerable<IDrawable> GetGameObjects()
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
                Console.WriteLine("Add new Bouncing dot!");

                var ball = new BouncingDot(_border.Edges);
                ball.Init();
                GameObjects.Add(ball);
            }
        }
    }
}
