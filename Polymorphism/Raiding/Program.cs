using System;
using System.Collections.Generic;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<BaseHero> raidGroup = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());

            while (raidGroup.Count < n)
            {
                string name = Console.ReadLine();
                string heroClass = Console.ReadLine();
                BaseHero hero = HeroFactory.CreateHero(name, heroClass);
                if (hero == null)
                {
                    Console.WriteLine("Invalid hero!");
                }
                else
                {
                    raidGroup.Add(hero);
                }
            }

            int bossHP = int.Parse(Console.ReadLine());
            int heroesPower = 0;
            foreach (var hero in raidGroup)
            {
                Console.WriteLine(hero.CastAbility());
                heroesPower += hero.Power;
            }

            if (bossHP > heroesPower)
            {
                Console.WriteLine("Defeat...");
            }
            else
            {
                Console.WriteLine("Victory!");
            }
        }
    }
}
