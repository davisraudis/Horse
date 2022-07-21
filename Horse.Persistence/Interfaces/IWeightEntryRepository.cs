using Horse.Business.Models.Interfaces;

namespace Horse.Persistence.Interfaces
{
    public interface IWeightEntryRepository
    {
        int Add(IWeightEntry weightEntry);

        IWeightEntry? Get(int weightEntryId);

        bool Update(IWeightEntry weightEntry);

        bool Delete(int id);

        IList<IWeightEntry>? GetByGoalId(int goalId);
    }
}
