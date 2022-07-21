namespace Horse.Business.Models.Interfaces
{
    public interface IWeightEntry
    {
        int Id { get; set; }
        public int GoalId { get; set; }
        double CurrentWeight { get; set; }
        string Description { get; set; }
        DateTime EntryDateTime { get; set; }
    }
}