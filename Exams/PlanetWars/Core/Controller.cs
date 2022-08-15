using PlanetWars.Core.Contracts;
using PlanetWars.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using PlanetWars.Utilities.Messages;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using System.Linq;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Models.Weapons;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;
        
        public Controller()
        {
            this.planets = new PlanetRepository();
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            var planet = this.planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (unitTypeName != "SpaceForces" && unitTypeName != "StormTroopers" && unitTypeName != "AnonymousImpactUnit")
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            IMilitaryUnit unit = null;

            if (unitTypeName == "SpaceForces")
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == "StormTroopers")
            {
                unit = new StormTroopers();
            }
            else if (unitTypeName == "AnonymousImpactUnit")
            {
                unit = new AnonymousImpactUnit();
            }

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);

            return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            var planet = this.planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Weapons.Any(u => u.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            if (weaponTypeName != "SpaceMissiles" && weaponTypeName != "NuclearWeapon" && weaponTypeName != "BioChemicalWeapon")
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            IWeapon weapon = null;

            if (weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return String.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            if (this.planets.FindByName(name) != null)
            {
                return String.Format(OutputMessages.ExistingPlanet, name);
            }
            else
            {
                IPlanet planet = new Planet(name, budget);
                this.planets.AddItem(planet);

                return String.Format(OutputMessages.NewPlanet, name);
            }
        }

        public string ForcesReport()
        {
            var sb = new StringBuilder();

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in this.planets.Models.OrderByDescending(p => p.MilitaryPower).ThenBy(p => p.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var planet_1 = this.planets.FindByName(planetOne);
            var planet_2 = this.planets.FindByName(planetTwo);

            var planet_1MP = planet_1.MilitaryPower;
            var planet_2MP = planet_2.MilitaryPower;

            IPlanet winner = null;
            IPlanet loser = null;

            if (planet_1MP == planet_2MP)
            {
                if ((planet_1.Weapons.Any(w => w.GetType().Name == "NuclearWeapon") && planet_2.Weapons.Any(w => w.GetType().Name == "NuclearWeapon")) || (planet_1.Weapons.Any(w => w.GetType().Name != "NuclearWeapon") && planet_2.Weapons.Any(w => w.GetType().Name != "NuclearWeapon")))
                {
                    var budgetSlashPlanet_1 = planet_1.Budget * 0.5;
                    var budgetSlashPlanet_2 = planet_2.Budget *0.5;
                    
                    planet_1.Spend(budgetSlashPlanet_1);
                    planet_2.Spend(budgetSlashPlanet_2);

                    return String.Format(OutputMessages.NoWinner);
                }
                else if (planet_1.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
                {
                    winner = planet_1;
                    loser = planet_2;
                }
                else if (planet_2.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
                {
                    winner = planet_2;
                    loser = planet_1;
                }
            }
            else if (planet_1MP > planet_2MP)
            {
                winner = planet_1;
                loser = planet_2;
            }
            else if (planet_1MP < planet_2MP)
            {
                winner = planet_2;
                loser = planet_1;
            }

            var winnerSlashBudget = winner.Budget * 0.5;
            var loserHalfBudget = loser.Budget * 0.5;
            winner.Spend(winnerSlashBudget);
            winner.Profit(loserHalfBudget);
            var loserAssets = loser.Army.Sum(u => u.Cost) + loser.Weapons.Sum(w => w.Price);
            winner.Profit(loserAssets);
            this.planets.RemoveItem(loser.Name);

            return String.Format(OutputMessages.WinnigTheWar, winner.Name, loser.Name);
        }

        public string SpecializeForces(string planetName)
        {
            var planet = this.planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NoUnitsFound));
            }

            planet.Spend(1.25);
            planet.TrainArmy();

            return String.Format(OutputMessages.ForcesUpgraded, planetName);
        }
    }
}
