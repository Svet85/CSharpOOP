using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string cmd = Console.ReadLine();
            while (cmd != "Beast!")
            {
                string[] info = Console.ReadLine().Split();
                string name = info[0];
                int age = int.Parse(info[1]);
                string gender = info[2];

                try
                {
                    Animal animal = null;

                    if (cmd == "Dog")
                    {
                        animal = new Dog(name, age, gender);
                    }
                    else if (cmd == "Cat")
                    {
                        animal = new Cat(name, age, gender);
                    }
                    else if (cmd == "Frog")
                    {
                        animal = new Frog(name, age, gender);
                    }
                    else if (cmd == "Kitten")
                    {
                        animal = new Kitten(name, age);
                    }
                    else if (cmd == "Tomcat")
                    {
                        animal = new Tomcat(name, age);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                cmd = Console.ReadLine();
            }

            foreach (var item in animals)
            {
                Console.WriteLine(item);
            }
        }
    }
}
