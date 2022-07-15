using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird
    {
        private const double WeightGain = 0.25;
        
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override string MakeSound()
        {
            return "Hoot Hoot";
        }

        public override void Feed(Food food)
        {
            string foodType = food.GetType().Name;
            if (foodType == "Meat")
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
