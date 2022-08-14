using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private IRepository<ICar> cars;
        private IRepository<IRacer> racers;
        private IMap map;
        
        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            if (type != "SuperCar" && type != "TunedCar")
            {
                throw new ArgumentException("Invalid car type!");
            }

            ICar car = null;

            if (type == "SuperCar")
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else if (type == "TunedCar")
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }

            this.cars.Add(car);

            return $"Successfully added car {make} {model} ({VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            var car = this.cars.FindBy(carVIN);

            if (car == null)
            {
                throw new ArgumentException("Car cannot be found!");
            }

            if (type != "ProfessionalRacer" && type != "StreetRacer")
            {
                throw new ArgumentException("Invalid racer type!");
            }

            IRacer racer = null;

            if (type == "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(username, car);
            }
            else if (type == "StreetRacer")
            {
                racer = new StreetRacer(username, car);
            }

            this.racers.Add(racer);

            return $"Successfully added racer {username}.";
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer one = this.racers.FindBy(racerOneUsername);
            IRacer two = this.racers.FindBy(racerTwoUsername);

            if (one == null)
            {
                return $"Racer {racerOneUsername} cannot be found!";
            }
            else if (two == null)
            {
                return $"Racer {racerTwoUsername} cannot be found!";
            }

            string result = map.StartRace(one, two);

            return result;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var racer in this.racers.Models.OrderByDescending(r => r.DrivingExperience).ThenBy(r => r.Username))
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
