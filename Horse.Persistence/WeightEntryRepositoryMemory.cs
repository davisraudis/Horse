using Horse.Business.Models.Interfaces;
using Horse.Persistence.Interfaces;

namespace Horse.Persistence
{
    public class WeightEntryRepositoryMemory : IWeightEntryRepository
    {
        public int currentWeightEntryId = 0;
        public readonly IList<IWeightEntry> _weightEntries = new List<IWeightEntry>();

        public int Add(IWeightEntry weightEntry)
        {
            // ToDo validation

            _weightEntries.Add(weightEntry);
            weightEntry.Id = currentWeightEntryId;
            currentWeightEntryId++;

            return currentWeightEntryId;
        }

        public IWeightEntry? Get(int weightEntryId)
        {
            return _weightEntries.FirstOrDefault(w => w.Id == weightEntryId);
        }

        public IList<IWeightEntry>? GetByGoalId(int goalId)
        {
            return _weightEntries.Where(w => w.GoalId == goalId).ToList();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(IWeightEntry weightEntry)
        {
            throw new NotImplementedException();
        }
    }
}
