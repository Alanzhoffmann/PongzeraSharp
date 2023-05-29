using PongzeraSharp;
using PongzeraSharp.Logics;

var window = new GameWindow(1200, 800);
var logic = new TestLogic(window);

logic.RunMainLoop();
