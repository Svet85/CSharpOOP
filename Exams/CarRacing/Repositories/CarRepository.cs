using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly ICollection<ICar> models;
        
        public CarRepository()
        {
            this.models = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models => (IReadOnlyCollection<ICar>)this.models;

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Car Repository.");
            }

            this.models.Add(model);
        }

        public ICar FindBy(string property)
        {
            var car = this.models.FirstOrDefault(c => c.VIN == property);

            return car;
        }

        public bool Remove(ICar model)
        {
            return this.models.Remove(model);
        }
    }
}
