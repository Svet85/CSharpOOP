using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double SummerIncrease = 1.6;
        private const double RefuelingModifier = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override void Drive(double km)
        {
            double requiredFuel = (FuelConsumption + SummerIncrease) * km;
            if (requiredFuel > this.FuelQuantity)
            {
                Console.WriteLine("Truck needs refueling");
            }
            else
            {
                Console.WriteLine($"Truck travelled {km} km");
                this.FuelQuantity -= requiredFuel;
            }
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (TankCapacity >= liters + FuelQuantity)
            {
                double add = liters * RefuelingModifier;
                this.FuelQuantity += add;
            }
            else
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
        }
    }
}
