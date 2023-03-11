using PongzeraSharp.Drawables;

namespace PongzeraSharp.Logics
{
    public class TestLogic : BaseLogic
    {
        public override IEnumerable<IDrawable> GetGameObjects()
        {
            yield return new Border();
            yield return new MovingDot();
        }
    }
}
