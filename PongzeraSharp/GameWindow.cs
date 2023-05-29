namespace PongzeraSharp
{
    public class GameWindow
    {
        public GameWindow(int width = 800, int height = 600)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; }
        public int Height { get; }
    }
}
