using System.Collections.Concurrent;
using PongzeraSharp.Drawables;

namespace PongzeraSharp.Logics
{
    public abstract class BaseLogic : IDrawable
    {
        protected readonly ConcurrentBag<IDrawable> GameObjects = new();

        public abstract IEnumerable<IDrawable> GetGameObjects();

        public virtual void Init()
        {
            if (GameObjects.Count != 0)
                GameObjects.Clear();

            foreach (var gameObject in GetGameObjects())
            {
                gameObject.Init();
                GameObjects.Add(gameObject);
            }
        }

        public virtual void Draw()
        {
            foreach (var gameObject in GameObjects)
                gameObject.Draw();
        }

        public virtual void Update(float deltaTime)
        {
            foreach (var gameObject in GameObjects)
                gameObject.Update(deltaTime);
        }
    }
}
