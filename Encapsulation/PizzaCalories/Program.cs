using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split();
                string[] doughInfo = Console.ReadLine().Split();
                var dough = new Dough(doughInfo[1], doughInfo[2], int.Parse(doughInfo[3]));
                var pizza = new Pizza(pizzaInfo[1], dough);

                string input = Console.ReadLine();
                while (input != "END")
                {
                    string[] toppingInfo = input.Split();
                    string name = toppingInfo[1];
                    int grams = int.Parse(toppingInfo[2]);
                    var topping = new Topping(name,grams);
                    pizza.AddTopping(topping);

                    input = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
