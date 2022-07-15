using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Cat : Feline
    {
        private const double WeightGain = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override string MakeSound()
        {
            return "Meow";
        }

        public override void Feed(Food food)
        {
            string foodType = food.GetType().Name;
            if ( foodType == "Vegetable" || foodType == "Meat")
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
