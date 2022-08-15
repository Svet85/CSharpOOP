﻿using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private ICollection<IWeapon> models;

        public WeaponRepository()
        {
            this.models = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => (IReadOnlyCollection<IWeapon>)this.models;

        public void AddItem(IWeapon model)
        {
            this.models.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            var weapon = this.models.FirstOrDefault(w => w.GetType().Name == name);

            return weapon;
        }

        public bool RemoveItem(string name)
        {
            var model = this.models.FirstOrDefault(w => w.GetType().Name == name);
            
            return this.models.Remove(model);
        }
    }
}
