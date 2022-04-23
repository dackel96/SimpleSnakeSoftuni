using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public void Draw(char symbol)
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.WriteLine(symbol);
        }
        public void Draw(int customX, int customY, char symbol)
        {
            Console.SetCursorPosition(customX, customY);
            Console.WriteLine(symbol);
        }
    }
}
