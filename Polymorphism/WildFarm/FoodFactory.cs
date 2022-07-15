using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class FoodFactory
    {
        public static Food CreateFood(string[] array)
        {
            Food food = null;
            string name = array[0];
            double gramms = double.Parse(array[1]);
            if (name == "Vegetable")
            {
                food = new Vegetable(gramms);
            }
            else if (name == "Meat")
            {
                food = new Meat(gramms);
            }
            else if (name == "Seeds")
            {
                food = new Seeds(gramms);
            }
            else if (name == "Fruit")
            {
                food = new Fruit(gramms);
            }

            return food;
        }
    }
}
