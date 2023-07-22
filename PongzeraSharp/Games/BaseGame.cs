using System.Collections.Concurrent;
using PongzeraSharp.Interfaces;
using Raylib_cs;

namespace PongzeraSharp.Games
{
    public abstract class BaseGame : IDraw, ILogic
    {
        private readonly ConcurrentBag<object> GameObjects = new();

        public BaseGame(GameWindow window)
        {
            Window = window;
        }

        protected IEnumerable<IDraw> Draws => GameObjects.OfType<IDraw>();
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

            foreach (var draw in Draws)
                draw.Draw();

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
            var validGameObject = false;

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
