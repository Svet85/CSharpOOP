using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private ICollection<IPlanet> models;

        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => (IReadOnlyCollection<IPlanet>)this.models;

        public void AddItem(IPlanet model)
        {
            this.models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            var planet = this.models.FirstOrDefault(p => p.Name == name);

            return planet;
        }

        public bool RemoveItem(string name)
        {
            var model = this.models.FirstOrDefault(p => p.Name == name);

            return this.models.Remove(model);
        }
    }
}
