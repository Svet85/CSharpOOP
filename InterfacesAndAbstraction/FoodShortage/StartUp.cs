using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBuyer> people = new Dictionary<string, IBuyer>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (info.Length == 4)
                {
                    var citizen = new Citizen(info[0], int.Parse(info[1]), info[2],info[3]);
                    people.Add(info[0], citizen);
                }
                else if (info.Length == 3)
                {
                    var rebel = new Rebel(info[0], int.Parse(info[1]), info[2]);
                    people.Add(info[0], rebel);
                }
            }
            
            string input = Console.ReadLine();
            while (input != "End")
            {
                if (people.ContainsKey(input))
                {
                    people[input].BuyFood();
                }

                input = Console.ReadLine();
            }

            int total = people.Values.Sum(x => x.Food);
            Console.WriteLine(total);
        }
    }
}
