using Horse.Business;
using Horse.Business.Models.Interfaces;
using Horse.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horse.Persistence
{
    public class WeightGoalRepositoryMemory : IWeightGoalRepository
    {
        public int currentWeightGoalId = 0;
        public readonly IList<IWeightGoal> _weightGoals = new List<IWeightGoal>();

        public int Add(IWeightGoal weightGoal)
        {
            // ToDo validation

            _weightGoals.Add(weightGoal);
            weightGoal.Id = currentWeightGoalId;
            currentWeightGoalId++;

            return currentWeightGoalId;
        }

        public IWeightGoal? Get(int goalId)
        {
            var weightGoal = _weightGoals.FirstOrDefault(g => g.Id == goalId);
            return weightGoal;
        }

        public bool Update(IWeightEntry weightEntry)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
