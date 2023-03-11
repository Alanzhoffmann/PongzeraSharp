using PongzeraSharp;
using PongzeraSharp.Logics;

var logic = new TestLogic();

var window = new GameWindow(logic);
window.RunMainLoop();
