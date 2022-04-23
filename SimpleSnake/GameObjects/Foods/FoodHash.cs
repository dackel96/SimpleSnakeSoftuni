using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodHash : Food
    {
        public FoodHash(Wall walls)
            : base(walls, '#', 3)
        {
        }
    }
}
