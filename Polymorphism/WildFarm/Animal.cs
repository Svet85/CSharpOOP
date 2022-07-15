using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public double FoodEaten { get; set; } = 0.0;

        public abstract string MakeSound();

        public abstract void Feed(Food food);
    }
}
