using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models
{
    public class Mace : Weapon
    {
        private int initialDamage = 25;

        public Mace(string name, int durability) : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            int damage = initialDamage;

            if (this.Durability == 0)
            {
                damage = 0;
            }
            else
            {
                this.Durability--;
            }

            return damage;
        }
    }
}
