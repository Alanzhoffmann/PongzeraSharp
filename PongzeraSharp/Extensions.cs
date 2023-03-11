using Raylib_cs;

namespace PongzeraSharp
{
    public static class Extensions
    {
        public static float GetBoundaryLeft(this Rectangle rectangle) => rectangle.x;

        public static float GetBoundaryRight(this Rectangle rectangle) => rectangle.x + rectangle.width;

        public static float GetBoundaryUp(this Rectangle rectangle) => rectangle.y;

        public static float GetBoundaryDown(this Rectangle rectangle) => rectangle.y + rectangle.height;

        public static float GetCenterHorizontal(this Rectangle rectangle) => rectangle.x + (rectangle.width / 2);

        public static float GetCenterVertical(this Rectangle rectangle) => rectangle.y + (rectangle.height / 2);
    }
}
