using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public Map()
        {
        }

        public string Fight(ICollection<IHero> players)
        {
            var knights = new List<Knight>();
            var barbarians = new List<Barbarian>();

            foreach (var hero in players)
            {
                if (hero.GetType().Name == "Knight")
                {
                    knights.Add((Knight)hero);
                }
                else
                {
                    barbarians.Add((Barbarian)hero);
                }
            }

            string result;

            while (true)
            {
                foreach (var knight in knights)
                {
                    if (knight.IsAlive)
                    {
                        foreach (var barb in barbarians)
                        {
                            if (barb.IsAlive)
                            {
                                barb.TakeDamage(knight.Weapon.DoDamage());
                            }
                        }
                    }
                }

                if (barbarians.All(b => !b.IsAlive))
                {
                    int deadKnights = knights.Count(k => !k.IsAlive);

                    result = $"The knights took {deadKnights} casualties but won the battle.";
                    break;
                }

                foreach (var barb in barbarians)
                {
                    if (barb.IsAlive)
                    {
                        foreach (var knight in knights)
                        {
                            if (knight.IsAlive)
                            {
                                knight.TakeDamage(barb.Weapon.DoDamage());
                            }
                        }
                    }
                }

                if (knights.All(k => !k.IsAlive))
                {
                    int deadBarbarians = barbarians.Count(b => !b.IsAlive);

                    result = $"The barbarians took {deadBarbarians} casualties but won the battle.";
                    break;
                }
            }

            return result;
        }
    }
}
