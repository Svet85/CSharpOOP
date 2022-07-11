using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IId> ids = new List<IId>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (info.Length == 3)
                {
                    ids.Add(new Citizen(info[0],int.Parse(info[1]),info[2]));
                }
                else if (info.Length == 2)
                {
                    ids.Add(new Robot(info[0],info[1]));
                }

                input = Console.ReadLine();
            }

            string fakeFlag = Console.ReadLine();
            foreach (var item in ids)
            {
                if (item.Id.EndsWith(fakeFlag))
                {
                    Console.WriteLine(item.Id);
                }
            }
        }
    }
}
