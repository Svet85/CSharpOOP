using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog : Mammal
    {
        private const double WeightGain = 0.40;
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override string MakeSound()
        {
            return "Woof!";
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
