using System.Numerics;
using PongzeraSharp.Interfaces;

namespace PongzeraSharp.Games.Test
{
    public class BouncingLogic : ILogic
    {
        private Vector2 _speed;
        private Vector2 _position;

        public BouncingLogic(float speedHorizontal, float speedVertical, float positionX, float positionY)
        {
            _speed = new Vector2(speedHorizontal, speedVertical);
            _position = new Vector2(positionX, positionY);
        }

        public float PositionX
        {
            get => _position[0];
            set => _position[0] = value;
        }

        public float PositionY
        {
            get => _position[1];
            set => _position[1] = value;
        }

        public float SpeedHorizontal
        {
            get => _speed[0];
            set => _speed[0] = value;
        }

        public float SpeedVertical
        {
            get => _speed[1];
            set => _speed[1] = value;
        }

        public bool MovingLeft => SpeedHorizontal < 0;
        public bool MovingUp => SpeedVertical < 0;

        public void Update(float deltaTime)
        {
            CalculateNewPosition(deltaTime);
        }

        public void InvertVerticalDirection() => SpeedVertical = -SpeedVertical;

        public void InvertHorizontalDirection() => SpeedHorizontal = -SpeedHorizontal;

        public override string ToString()
        {
            return $"Hor speed: {SpeedHorizontal}, Ver speed: {SpeedVertical}";
        }

        private void CalculateNewPosition(float deltaTime)
        {
            PositionX += SpeedHorizontal * deltaTime;
            PositionY += SpeedVertical * deltaTime;
        }
    }
}
