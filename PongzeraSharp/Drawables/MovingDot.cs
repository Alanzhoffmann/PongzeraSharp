using PongzeraSharp.Interfaces;
using Raylib_cs;

namespace PongzeraSharp.Drawables
{
    public class MovingDot : IDraw, ILogic
    {
        private const int PlayerSpeed = 300;
        private Rectangle _dot = new(0, 0, 10, 10);

        public void Draw()
        {
            Raylib.DrawRectangleRec(_dot, Color.BLACK);
        }

        public void Update(float deltaTime)
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                _dot.x += PlayerSpeed * -deltaTime;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                _dot.x += PlayerSpeed * deltaTime;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                _dot.y += PlayerSpeed * -deltaTime;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                _dot.y += PlayerSpeed * deltaTime;
        }
    }
}
