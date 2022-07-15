using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            
            string inp = Console.ReadLine();
            while (inp != "End")
            {
                string[] animalInfo = inp.Split();
                
                Animal animal = AnimalFactory.CreateAnimal(animalInfo);
                
                string[] foodInfo = Console.ReadLine().Split();
                
                Food food = FoodFactory.CreateFood(foodInfo);
                
                Console.WriteLine(animal.MakeSound());
                
                animal.Feed(food);
                animals.Add(animal);

                inp = Console.ReadLine();
            }

            foreach (var animall in animals)
            {
                Console.WriteLine(animall);
            }
        }
    }
}
