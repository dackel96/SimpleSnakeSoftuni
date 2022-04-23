using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodAsterisk : Food
    {
        public FoodAsterisk(Wall walls) 
            : base(walls, '*', 1)
        {
        }
    }
}
