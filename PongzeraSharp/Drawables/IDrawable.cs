namespace PongzeraSharp.Drawables
{
    public interface IDrawable
    {
        void Init();
        void Draw();
        void Update(float deltaTime);
    }
}
