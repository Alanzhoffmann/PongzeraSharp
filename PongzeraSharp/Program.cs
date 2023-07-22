using PongzeraSharp;
using PongzeraSharp.Games.Snake;

var window = new GameWindow(1200, 800);
//var logic = new TestGame(window);
var logic = new SnakeGame(window);

logic.RunMainLoop();
