using SimpleSnake.GameObjects.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char symbol = '\u25CF';
        private Queue<Point> snake;
        private readonly Food[] foods;
        private readonly Wall wall;
        private int foodIndex;
        public Snake(Wall wall)
        {
            this.wall = wall;
            this.foods = new Food[]
            {
                new FoodAsterisk(this.wall),
                new FoodDollar(this.wall),
                new FoodHash(this.wall)
            };
            this.foodIndex = 0;
            this.CreateSnake();
        }
        private int RandomFoodIndex()
            => new Random().Next(0, this.foods.Length);
        public bool TryMove(Point point)
        {
            Point snakeHead = this.snake.Last();
            int nextX = snakeHead.X + point.X;
            int nextY = snakeHead.Y + point.Y;
            bool isSnake = this.snake.Any(x => x.X == nextX && x.Y == nextY);
            if (isSnake)
            {
                return false;
            }
            bool isWall = nextX < 1 || nextY < 1 || nextX >= this.wall.X || nextY >= this.wall.Y;
            if (isWall)
            {
                return false;
            }
            bool isFood = this.foods[foodIndex].X == nextX && this.foods[foodIndex].Y == nextY;
            if (isFood)
            {
                this.Eat(nextX, nextY);
            }
            Point snakePoint = new Point(nextX, nextY);
            this.snake.Enqueue(snakePoint);
            snakePoint.Draw(symbol);
            Point lastPoint = this.snake.Dequeue();
            lastPoint.Draw(' ');
            return true;
        }

        private void Eat(int x, int y)
        {
            Food food = this.foods[foodIndex];
            for (int i = 0; i < food.Points; i++)
            {
                this.snake.Enqueue(new Point(x, y));
            }
            this.foodIndex = RandomFoodIndex();
            this.foods[foodIndex].SetRandomPosition(snake);
        }

        private void CreateSnake()
        {
            this.snake = new Queue<Point>();

            for (int i = 1; i <= 6; i++)
            {
                Point point = new Point(i, 1);
                snake.Enqueue(point);
                point.Draw(symbol);
            }
            this.foodIndex = RandomFoodIndex();
            this.foods[this.foodIndex].SetRandomPosition(this.snake);
        }
    }
}
