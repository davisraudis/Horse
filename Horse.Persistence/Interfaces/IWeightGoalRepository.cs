using Horse.Business.Models.Interfaces;

namespace Horse.Persistence.Interfaces
{
    public interface IWeightGoalRepository
    {
        int Add(IWeightGoal weightGoalDto);

        public IWeightGoal Get(int goalId);

        bool Update(IWeightEntry weightEntry);

        bool Delete(int id);
    }
}