using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const int defaultCalories = 2;
        private string floutType;
        private string bakingTechnique;
        private int grams;

        public Dough(string flourType, string bakingTechnique, int grams)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Grams = grams;
        }

        public string FlourType
        {
            get { return floutType; }
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                floutType = value;
            }
        }

        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value; }
        }

        public int Grams
        {
            get { return grams; }
            private set {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                grams = value; }
        }

        public double CaloriesperGram => FlourModifier() * TechniqueModifier() * (defaultCalories * Grams);

        private double TechniqueModifier()
        {
            if (BakingTechnique.ToLower() == "crispy")
            {
                return 0.9;
            }
            else if (BakingTechnique.ToLower() == "chewy")
            {
                return 1.1;
            }
            else if (BakingTechnique.ToLower() == "homemade")
            {
                return 1.0;
            }

            return 0.0;
        }

        private double FlourModifier()
        {
            if (FlourType.ToLower() == "white")
            {
                return 1.5;
            }
            else if (FlourType.ToLower() == "wholegrain")
            {
                return 1.0;
            }

            return 0.0;

        }
    }
}
