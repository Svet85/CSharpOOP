using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        private const double WeightGain = 0.10;
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override string MakeSound()
        {
            return "Squeak";
        }

        public override void Feed(Food food)
        {
            string foodType = food.GetType().Name;
            if (foodType == "Vegetable" || foodType == "Fruit")
            {
                CalcGain(food.Quantity);
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {foodType}!");
            }
        }

        private void CalcGain(double gramms)
        {
            this.Weight += WeightGain * gramms;
            this.FoodEaten += gramms;
        }
    }
}
