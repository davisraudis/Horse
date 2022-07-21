using Horse.Business.Models;
using Horse.Business.Models.Interfaces;

namespace Horse.Business.Interfaces
{
    public interface IWeightProgressCalculator
    {
        double? CalculateCurrentProgressInPercent(IWeightGoal goal, IList<IWeightEntry> weightEntries);
    }
}