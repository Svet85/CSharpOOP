using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IEquipment> eqipment;
        private readonly ICollection<IGym> gyms;

        public Controller()
        {
            this.eqipment = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            if (athleteType != "Boxer" && athleteType != "Weightlifter")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            var gym = this.gyms.FirstOrDefault(g => g.Name == gymName);

            if ((athleteType == "Boxer" && gym.GetType().Name != "BoxingGym") || (athleteType == "Weightlifter" && gym.GetType().Name != "WeightliftingGym"))
            {
                return OutputMessages.InappropriateGym;
            }

            IAthlete athlete = null;

            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }

            if (athleteType == "Weightlifter")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }

            gym.AddAthlete(athlete);

            return String.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType != "BoxingGloves" && equipmentType != "Kettlebell")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            IEquipment eqipment;

            if (equipmentType == "BoxingGloves")
            {
                eqipment = new BoxingGloves();
            }
            else
            {
                eqipment = new Kettlebell();
            }

            this.eqipment.Add(eqipment);

            return String.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType != "BoxingGym" && gymType != "WeightliftingGym")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            IGym gym = null;

            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else
            {
                gym = new WeightliftingGym(gymName);
            }

            this.gyms.Add(gym);

            return String.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            var gym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            double weightSum = gym.EquipmentWeight;

            return String.Format(OutputMessages.EquipmentTotalWeight, gymName, weightSum);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            var equipment = this.eqipment.FindByType(equipmentType);
            var gym = this.gyms.FirstOrDefault(g => g.Name == gymName);

            if (equipment == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            gym.AddEquipment(equipment);
            this.eqipment.Remove(equipment);

            return String.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gym in this.gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            var gym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            gym.Exercise();
            int count = gym.Athletes.Count;

            return String.Format(OutputMessages.AthleteExercise, count);
        }
    }
}
