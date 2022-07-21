using Horse.Business.Interfaces;
using Horse.Business.Models;
using Horse.Business.Models.Interfaces;

namespace Horse.Business
{
    public class WeightProgressCalculator : IWeightProgressCalculator
    {
        public double? CalculateCurrentProgressInPercent(IWeightGoal goal, IList<IWeightEntry> weightEntries)
        {
            if (weightEntries == null)
            {
                return null;
            }

            // Only the latest entry is relevant to calculate the current progress
            var latestEntry = GetLatestEntry(weightEntries);
            var goalTargetCurrentWeightDiff = goal.TargetWeight - goal.CurrentWeight;

            if (goalTargetCurrentWeightDiff == 0)
            {
                // The goal is already completed
                return 100;
            }

            var weightChange = latestEntry.CurrentWeight - goal.CurrentWeight;

            if (weightChange == 0)
            {
                // No changes in weight
                // 0 progress
                return 0;
            }

            // This will return a positive percent if it is progress towards positive direction, e.g. if someone aim is to lose weight and they did lose their weight, it is in a positive direction
            // This will return a negative percent if it is progress towards negative direction, e.g. if someone aim is to lose weight and gained weight, it is in a negative direction
            return weightChange / goalTargetCurrentWeightDiff;
        }

        // ToDo - This should really be in some other class to stick to Single Responsibility , no time!
        private IWeightEntry GetLatestEntry(IList<IWeightEntry> weightEntries)
        {
            return weightEntries.OrderByDescending(e => e.EntryDateTime).FirstOrDefault();
        }
    }
}
