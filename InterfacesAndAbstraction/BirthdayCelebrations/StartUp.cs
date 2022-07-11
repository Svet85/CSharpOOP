using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> birthdates = new List<IBirthable>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = info[0];
                if (type == "Citizen")
                {
                    birthdates.Add(new Citizen(info[1],int.Parse(info[2]), info[3], info[4]));
                }
                else if (type == "Pet")
                {
                    birthdates.Add(new Pet(info[1],info[2]));
                }

                input = Console.ReadLine();
            }

            string dateFlag = Console.ReadLine();
            foreach (var birthable in birthdates)
            {
                if (birthable.Birthdate.EndsWith(dateFlag))
                {
                    Console.WriteLine(birthable.Birthdate);
                }
            }
        }
    }
}
