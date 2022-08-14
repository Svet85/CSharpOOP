using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public Map()
        {
        }

        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return "Race cannot be completed because both racers are not available!";
            }

            if (!racerOne.IsAvailable())
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }
            else if (!racerTwo.IsAvailable())
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }

            double multiplierRacerOne = racerOne.RacingBehavior == "strict" ? 1.2 : 1.1;
            var racerOneChance = racerOne.Car.HorsePower * racerOne.DrivingExperience * multiplierRacerOne;

            double multiplierRacerTwo = racerTwo.RacingBehavior == "strict" ? 1.2 : 1.1;
            var racerTwoChance = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * multiplierRacerTwo;

            string winnerUsername = racerOneChance > racerTwoChance ? racerOne.Username : racerTwo.Username;

            racerOne.Race();
            racerTwo.Race();

            return $"{racerOne.Username} has just raced against {racerTwo.Username}! {winnerUsername} is the winner!";
        }
    }
}
