namespace SimpleSnake
{
    using SimpleSnake.Core;
    using SimpleSnake.GameObjects;
    using SimpleSnake.GameObjects.Foods;
    using System.Collections.Generic;
    using System.Threading;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();
            Wall walls = new Wall(50, 10);
            Snake snakie = new Snake(walls);
            Engine engine = new Engine(snakie, walls);
            engine.Run();

        }
    }
}
