using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class AnimalFactory
    {
        public static Animal CreateAnimal(string[] array)
        {
            Animal newAnimal = null;


            string animal = array[0];
            string name = array[1];
            double weight = double.Parse(array[2]);

            if (animal == "Hen")
            {
                double wings = double.Parse(array[3]);
                newAnimal = new Hen(name, weight, wings);
            }
            else if (animal == "Owl")
            {
                double wings = double.Parse(array[3]);
                newAnimal = new Owl(name, weight, wings);
            }
            else if (animal == "Mouse")
            {
                string region = array[3];
                newAnimal = new Mouse(name, weight, region);
            }
            else if (animal == "Cat")
            {
                string region = array[3];
                string breed = array[4];
                newAnimal = new Cat(name, weight, region, breed);
            }
            else if (animal == "Dog")
            {
                string region = array[3];
                newAnimal = new Dog(name, weight, region);
            }
            else if (animal == "Tiger")
            {
                string region = array[3];
                string breed = array[4];
                newAnimal = new Tiger(name, weight, region, breed);
            }


            return newAnimal;
        }
    }
}
