using PongzeraSharp.Interfaces;

namespace PongzeraSharp.Logics
{
    public sealed class ElapsedLogic : ILogic
    {
        private readonly TimeSpan _interval;
        private readonly Action _action;
        private readonly Func<bool> _orCondition;

        private TimeSpan _elapsedTime = TimeSpan.Zero;

        public ElapsedLogic(Action action, TimeSpan interval, Func<bool> orCondition)
        {
            _action = action;
            _interval = interval;
            _orCondition = orCondition;
        }

        public ElapsedLogic(Action action, TimeSpan interval) : this(action, interval, () => false)
        {
            _action = action;
            _elapsedTime = interval;
        }

        public void Update(float deltaTime)
        {
            _elapsedTime += TimeSpan.FromSeconds(deltaTime);

            bool runAction = false;

            if (_orCondition() || _elapsedTime > _interval)
            {
                _elapsedTime = TimeSpan.Zero;
                runAction = true;
            }

            if (runAction)
            {
                _action();
            }
        }
    }
}
