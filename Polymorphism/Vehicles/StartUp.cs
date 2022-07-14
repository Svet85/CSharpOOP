using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();
            var car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            var truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            var bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split();
                if (cmd[0] == "Drive")
                {
                    double km = double.Parse(cmd[2]);
                    if (cmd[1] == "Car")
                    {
                        car.Drive(km);
                    }
                    else if (cmd[1] == "Truck")
                    {
                        truck.Drive(km);
                    }
                    else if (cmd[1] == "Bus")
                    {
                        bus.IsOn = true;
                        bus.Drive(km);
                    }
                }
                else if (cmd[0] == "DriveEmpty")
                {
                    bus.IsOn = false;
                    bus.Drive(double.Parse(cmd[2]));
                }
                else if (cmd[0] == "Refuel")
                {
                    double liters = double.Parse(cmd[2]);
                    if (cmd[1] == "Car")
                    {
                        car.Refuel(liters);
                    }
                    else if (cmd[1] == "Truck")
                    {
                        truck.Refuel(liters);
                    }
                    else if (cmd[1] == "Bus")
                    {
                        bus.Refuel(liters);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");

        }
    }
}
