using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private ICollection<IRacer> models;

        public RacerRepository()
        {
            this.models = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models => (IReadOnlyCollection<IRacer>)this.models;

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Racer Repository.");
            }

            this.models.Add(model);
        }

        public IRacer FindBy(string property)
        {
            var racer = this.models.FirstOrDefault(r => r.Username == property);

            return racer;
        }

        public bool Remove(IRacer model)
        {
            return this.models.Remove(model);
        }
    }
}
