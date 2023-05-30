using PongzeraSharp.Drawables;
using PongzeraSharp.Logics;

namespace PongzeraSharp.Pong
{
    public class PongLogic : BaseLogic
    {
        public PongLogic(GameWindow window) : base(window)
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
