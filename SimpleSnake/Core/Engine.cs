using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private Direction direction;
        private Dictionary<Direction, Point> pointDirections;
        private Snake snake;
        private Wall walls;
        public Engine(Snake snake, Wall wall)
        {
            this.snake = snake;
            this.direction = Direction.Right;
            this.walls = wall;
            this.pointDirections = new Dictionary<Direction, Point>()
            {
                {Direction.Left,new Point(-1,0) },
                {Direction.Right,new Point(1,0) },
                {Direction.Up,new Point(0,-1) },
                {Direction.Down,new Point(0,1) }
            };
        }
        public void Run()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    this.GetDirection();
                }
                bool tryMove = this.snake.TryMove(this.pointDirections[this.direction]);
                if (!tryMove)
                {
                    Console.SetCursorPosition(10, this.walls.Y + 1);
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("((((!!!G>A>M>E|||O<V<E<R!!!)))");
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    break;
                }
                Thread.Sleep(150);
            }
        }

        private void GetDirection()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                if (direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }
        }
    }
}
