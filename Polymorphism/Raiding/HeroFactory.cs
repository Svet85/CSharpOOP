using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class HeroFactory
    {

        public static BaseHero CreateHero(string name, string heroClass)
        {
            BaseHero hero = null;

            if (heroClass == "Druid")
            {
                hero = new Druid(name);
            }
            else if (heroClass == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (heroClass == "Rogue")
            {
                hero = new Rogue(name);
            }
            else if (heroClass == "Warrior")
            {
                hero = new Warrior(name);
            }

            return hero;
        }
    }
}
