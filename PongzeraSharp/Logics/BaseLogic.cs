using PongzeraSharp.Drawables;

namespace PongzeraSharp.Logics
{
    public abstract class BaseLogic : IDrawable
    {
        private readonly List<IDrawable> _gameObjects = new();

        public abstract IEnumerable<IDrawable> GetGameObjects();

        public virtual void Init()
        {
            if (_gameObjects.Count != 0)
                _gameObjects.Clear();

            foreach (var gameObject in GetGameObjects())
            {
                gameObject.Init();
                _gameObjects.Add(gameObject);
            }
        }

        public void Draw()
        {
            foreach (var gameObject in _gameObjects)
                gameObject.Draw();
        }

        public void Update(float deltaTime)
        {
            foreach (var gameObject in _gameObjects)
                gameObject.Update(deltaTime);
        }
    }
}
