using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private ICollection<IMilitaryUnit> models;

        public UnitRepository()
        {
            this.models = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => (IReadOnlyCollection<IMilitaryUnit>)this.models;

        public void AddItem(IMilitaryUnit model)
        {
            this.models.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            var unit = this.models.FirstOrDefault(u => u.GetType().Name == name);

            return unit;
        }

        public bool RemoveItem(string name)
        {
            var model = this.models.FirstOrDefault(u => u.GetType().Name == name);

            return this.models.Remove(model);
        }
    }
}
