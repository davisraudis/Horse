using Horse.Business.Models.Interfaces;

namespace Horse.Business.Models
{
    public class WeightGoal : IWeightGoal
    {
        public int Id { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public double TargetWeight { get; set; }
        public double CurrentWeight { get; set; }
        public WeightUnit Unit { get; set; }
    }
}