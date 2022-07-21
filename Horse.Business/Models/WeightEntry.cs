using Horse.Business.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horse.Business.Models
{
    public class WeightEntry : IWeightEntry
    {
        public int Id { get; set; }
        public int GoalId { get; set; }
        public double CurrentWeight { get; set; }
        public string Description { get; set; }
        public DateTime EntryDateTime { get; set; }
    }
}
