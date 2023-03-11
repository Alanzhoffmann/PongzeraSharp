using Raylib_cs;

namespace PongzeraSharp.Drawables
{
    public class Border : IDrawable
    {
        public Rectangle Edges { get; private set; }

        public void Init()
        {
            var windowWidth = Raylib.GetRenderWidth();
            var windowHeight = Raylib.GetRenderHeight();

            const int margin = 10;

            Edges = new Rectangle(margin, margin, windowWidth - margin * 2, windowHeight - margin * 2);
        }

        public void Draw()
        {
            Raylib.DrawRectangleLinesEx(Edges, 1, Color.BLACK);
        }

        public void Update(float deltaTime)
        {
        }
    }
}
