using Raylib_cs;

namespace PongzeraSharp
{
    public class GameWindow
    {
        public GameWindow(int width = 800, int height = 600, string title = "Default title")
        {
            Width = width;
            Height = height;
            Title = title;
        }

        public int Width { get; }
        public int Height { get; }
        public string Title { get; }

        public void Init()
        {
            Raylib.InitWindow(Width, Height, Title);

            SetFPSToRefreshRate();
        }

        private static void SetFPSToRefreshRate()
        {
            var currentMonitor = Raylib.GetCurrentMonitor();
            var refreshRate = Raylib.GetMonitorRefreshRate(currentMonitor);
            Raylib.SetTargetFPS(refreshRate);
        }
    }
}
