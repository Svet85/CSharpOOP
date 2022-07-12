using System;

namespace ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] cmd = input.Split();
                string name = cmd[0];
                string country = cmd[1];
                int age = int.Parse(cmd[2]);
                IPerson citizen = new Citizen(name,country,age);
                IResident citizenn = new Citizen(name,country,age);



                Console.WriteLine(citizen.GetName());
                Console.WriteLine(citizenn.GetName());


                input = Console.ReadLine();
            }
        }
    }
}
