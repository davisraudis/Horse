namespace Horse.Business.Models.Interfaces
{
    public interface IWeightGoal
    {
        int Id { get; set; }
        DateTime EndDate { get; set; }
        DateTime StartDate { get; set; }
        double TargetWeight { get; set; }
        double CurrentWeight { get; set; }
        WeightUnit Unit { get; set; }
    }
}