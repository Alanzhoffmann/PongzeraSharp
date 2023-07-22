using PongzeraSharp.Drawables;

namespace PongzeraSharp.Games.Pong
{
    public class PongGame : BaseGame
    {
        public PongGame(GameWindow window) : base(window)
        {
        }

        public override void Init()
        {
            base.Init();

            AddGameObject(new Border(Window));
            AddGameObject(new MovingDot());
        }
    }
}
