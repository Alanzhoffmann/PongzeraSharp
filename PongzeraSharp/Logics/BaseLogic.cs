using System.Collections.Concurrent;
using PongzeraSharp.Interfaces;
using Raylib_cs;

namespace PongzeraSharp.Logics
{
    public abstract class BaseLogic : IDraw, ILogic
    {
        private readonly ConcurrentBag<object> GameObjects = new();

        public BaseLogic(GameWindow window)
        {
            Window = window;
        }

        protected IEnumerable<IDraw> Drawables => GameObjects.OfType<IDraw>();
        protected IEnumerable<ILogic> Logics => GameObjects.OfType<ILogic>();

        protected GameWindow Window { get; }

        public virtual void Init()
        {
            Window.Init();

            if (!GameObjects.IsEmpty)
                GameObjects.Clear();
        }

        public virtual void Draw()
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.RAYWHITE);

            //Raylib.DrawText("Hello C# Window", 10, 10, 20, Color.BLACK);

            foreach (var drawable in Drawables)
                drawable.Draw();

            Raylib.EndDrawing();
        }

        public virtual void Update(float deltaTime)
        {
            foreach (var logic in Logics)
                logic.Update(deltaTime);
        }

        public void RunMainLoop()
        {
            Init();

            while (!Raylib.WindowShouldClose())
            {
                var deltaTime = Raylib.GetFrameTime();

                Update(deltaTime);

                Draw();
            }

            Raylib.CloseWindow();
        }

        protected void AddGameObject(object gameObject)
        {
            bool validGameObject = false;

            if (gameObject is IInitialize initialize)
            {
                initialize.Init();
                validGameObject = true;
            }

            if (gameObject is IDraw || gameObject is ILogic)
            {
                validGameObject = true;
            }

            if (!validGameObject)
            {
                throw new InvalidOperationException("This game object is not valid!");
            }

            lock (GameObjects)
            {
                GameObjects.Add(gameObject);
            }
        }
    }
}
