using PongzeraSharp.Interfaces;
using Raylib_cs;

namespace PongzeraSharp.Drawables
{
    public class Border : IDraw
    {
        public Border(GameWindow window)
        {
            const int margin = 10;

            Edges = new Rectangle(margin, margin, window.Width - margin * 2, window.Height - margin * 2);
        }

        public Rectangle Edges { get; private set; }

        public void Draw()
        {
            Raylib.DrawRectangleLinesEx(Edges, 1, Color.BLACK);
        }
    }
}
