using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char WallSymbol = '\u25A0';
        public Wall(int x, int y)
            : base(x, y)
        {
            this.InitializeWall();
        }

        private void InitializeWall()
        {
            this.Horizontal(0);
            this.Horizontal(this.Y);

            this.Vertical(0);
            this.Vertical(this.X);
        }
        private void Horizontal(int Y)
        {
            for (int x = 0; x < this.X; x++)
            {
                this.Draw(x, Y, WallSymbol);
            }
        }
        private void Vertical(int X)
        {
            for (int y = 0; y < this.Y; y++)
            {
                this.Draw(X, y, WallSymbol);
            }
        }
    }
}
