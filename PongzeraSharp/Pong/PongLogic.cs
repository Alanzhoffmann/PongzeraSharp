using PongzeraSharp.Drawables;
using PongzeraSharp.Logics;

namespace PongzeraSharp.Pong
{
    public class PongLogic : BaseLogic
    {
        public PongLogic(GameWindow window) : base(window)
        {
        }

        public override IEnumerable<IDrawable> GetDrawables()
        {
            yield return new Border();
            yield return new MovingDot();
        }
    }
}
