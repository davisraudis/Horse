using Horse.Business;

namespace Horse.Api.Dtos
{
    public class WeightGoalDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TargetWeight { get; set; }

        public double CurrentWeight { get; set; }
        public WeightUnit Unit { get; set; }
    }
}
