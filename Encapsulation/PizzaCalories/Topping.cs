using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const int defaultCalories = 2;
        private string type;
        private int grams;

        public Topping(string type, int grams)
        {
            Type = type;
            Grams = grams;
        }

        public string Type
        {
            get { return type; }
            private set {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value; }
        }


        public int Grams
        {
            get { return grams; }
            private set {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }
                grams = value; }
        }

        public double CaloriesPerGram => ToppingModifier() * (defaultCalories * Grams);

        private double ToppingModifier()
        {
            if (Type.ToLower() == "meat")
            {
                return 1.2;
            }
            else if (Type.ToLower() == "veggies")
            {
                return 0.8;
            }
            else if (Type.ToLower() == "cheese")
            {
                return 1.1;
            }
            else if (Type.ToLower() == "sauce")
            {
                return 0.9;
            }

            return 0.0;
        }
    }
}
