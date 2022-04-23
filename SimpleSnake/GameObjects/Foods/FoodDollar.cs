using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodDollar : Food
    {
        public FoodDollar(Wall walls)
            : base(walls, '$', 2)
        {
        }
    }
}
