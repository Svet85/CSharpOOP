using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double ConditionningModifier = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public bool IsOn { get; set; } = false;

        public override void Drive(double km)
        {
            if (IsOn)
            {
                double requiredFuel = (FuelConsumption + ConditionningModifier) * km;
                if (requiredFuel > this.FuelQuantity)
                {
                    Console.WriteLine("Bus needs refueling");
                }
                else
                {
                    Console.WriteLine($"Bus travelled {km} km");
                    this.FuelQuantity -= requiredFuel;
                }
            }
            else
            {
                double requiredFuel = FuelConsumption * km;
                if (requiredFuel > this.FuelQuantity)
                {
                    Console.WriteLine("Bus needs refueling");
                }
                else
                {
                    Console.WriteLine($"Bus travelled {km} km");
                    this.FuelQuantity -= requiredFuel;
                }
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
                this.FuelQuantity += liters;
            }
            else
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
        }
    }

}

