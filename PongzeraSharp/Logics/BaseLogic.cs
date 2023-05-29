using System.Collections.Concurrent;
using PongzeraSharp.Drawables;
using Raylib_cs;

namespace PongzeraSharp.Logics
{
    public abstract class BaseLogic : IDrawable
    {
        protected readonly ConcurrentBag<IDrawable> Drawables = new();

        public BaseLogic(GameWindow window)
        {
            Window = window;
        }

        public GameWindow Window { get; }

        public abstract IEnumerable<IDrawable> GetDrawables();

        public virtual void Init()
        {
            Raylib.InitWindow(Window.Width, Window.Height, "Test");

            SetFPSToRefreshRate();

            if (!Drawables.IsEmpty)
                Drawables.Clear();

            foreach (var drawable in GetDrawables())
            {
                drawable.Init();
                Drawables.Add(drawable);
            }
        }

        public virtual void Draw()
        {
            foreach (var drawable in Drawables)
                drawable.Draw();
        }

        public virtual void Update(float deltaTime)
        {
            foreach (var drawable in Drawables)
                drawable.Update(deltaTime);
        }

        public void RunMainLoop()
        {
            Init();

            while (!Raylib.WindowShouldClose())
            {
                var deltaTime = Raylib.GetFrameTime();
                Update(deltaTime);

                Raylib.BeginDrawing();

                Raylib.ClearBackground(Color.RAYWHITE);

                //Raylib.DrawText("Hello C# Window", 10, 10, 20, Color.BLACK);

                Draw();

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }

        private static void SetFPSToRefreshRate()
        {
            var currentMonitor = Raylib.GetCurrentMonitor();
            var refreshRate = Raylib.GetMonitorRefreshRate(currentMonitor);
            Raylib.SetTargetFPS(refreshRate);
        }
    }
}
