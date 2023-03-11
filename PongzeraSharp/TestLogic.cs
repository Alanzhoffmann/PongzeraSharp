using Raylib_cs;

namespace PongzeraSharp
{
    public class TestLogic : IDrawable
    {
        private const int PlayerSpeed = 300;

        private Rectangle _dot = new(0, 0, 10, 10);
        private Rectangle _border;

        public TestLogic()
        {
        }

        public void Init()
        {
            var windowWidth = Raylib.GetRenderWidth();
            var windowHeight = Raylib.GetRenderHeight();

            const int margin = 10;

            _border = new Rectangle(margin, margin, windowWidth - (margin * 2), windowHeight - (margin * 2));
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

        public void Draw()
        {
            Raylib.DrawRectangleLinesEx(_border, 1, Color.BLACK);

            Raylib.DrawRectangleRec(_dot, Color.BLACK);
        }
    }
}
