using Raylib_cs;

namespace PongzeraSharp
{
    public class GameWindow
    {
        public GameWindow(IDrawable logic, int width = 800, int height = 600)
        {
            Logic = logic;
            Width = width;
            Height = height;
        }

        public int Width { get; }
        public int Height { get; }
        public IDrawable Logic { get; }

        public void InitMainLoop()
        {
            Raylib.InitWindow(800, 600, "Test");

            Logic.Init();

            while (!Raylib.WindowShouldClose())
            {
                var deltaTime = Raylib.GetFrameTime();
                Logic.Update(deltaTime);

                Raylib.BeginDrawing();

                Raylib.ClearBackground(Color.RAYWHITE);

                Raylib.DrawText("Hello C# Window", 10, 10, 20, Color.BLACK);

                Logic.Draw();

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
