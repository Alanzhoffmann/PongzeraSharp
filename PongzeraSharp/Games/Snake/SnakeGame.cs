using PongzeraSharp.Drawables;

namespace PongzeraSharp.Games.Snake
{
    public sealed class SnakeGame : BaseGame
    {
        public SnakeGame(GameWindow window) : base(window)
        {
        }

        public override void Init()
        {
            base.Init();

            var border = new Border(Window);
            var snakePlayer = new SnakePlayer(border);

            AddGameObject(border);
            AddGameObject(snakePlayer);
        }
    }
}
