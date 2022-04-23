using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public abstract class Food : Point
    {
        private readonly Wall walls;
        private readonly char symbol;
        private readonly Random random;
        public Food(Wall walls, char symbol, int points)
            : base(0, 0)
        {
            this.walls = walls;
            this.symbol = symbol;
            this.Points = points;
            this.random = new Random();
        }
        public int Points { get; private set; }
        public void SetRandomPosition(Queue<Point> snake)
        {
            this.X = this.random.Next(1, this.walls.X - 1);
            this.Y = this.random.Next(1, this.walls.Y - 1);
            bool isInSnake = snake.Any(x => x.X == this.X && x.Y == this.Y);
            while (isInSnake)
            {
                this.X = this.random.Next(1, this.walls.X - 1);
                this.Y = this.random.Next(1, this.walls.Y - 1);
                isInSnake = snake.Any(x => x.X == this.X && x.Y == this.Y);
            }
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            this.Draw(symbol);
            Console.BackgroundColor = ConsoleColor.DarkGray;
        }
    }
}
