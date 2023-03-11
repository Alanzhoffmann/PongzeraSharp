// See https://aka.ms/new-console-template for more information
using Raylib_cs;

Console.WriteLine("Hello, World!");

Raylib.InitWindow(800, 600, "Test");

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.RAYWHITE);

    Raylib.DrawText("Hello C# Window", 10, 10, 20, Color.BLACK);

    Raylib.EndDrawing();
}

Raylib.CloseWindow();
