using Horse.Business.Models;
using Horse.Business.Models.Interfaces;

namespace Horse.Business.Tests
{
    public class Tests
    {
        // ToDo Order tests

        [Test]
        public void ImHalfWayThere()
        {
            // Assign
            var goalMock = new WeightGoal
            {
                CurrentWeight = 80,
                TargetWeight = 60,
                StartDate = new DateTime(2022, 1, 1),
                EndDate = new DateTime(2022, 2, 1)
            };

            var weightEntry = new WeightEntry
            {
                CurrentWeight = 70,
                EntryDateTime = new DateTime(2022, 1, 15),
                Description = "I lost some weight!"
            };

            var weightEntriesMock = new List<IWeightEntry>
            {
               weightEntry
            };

            var calculator = new WeightProgressCalculator();

            // Act
            var progress = calculator.CalculateCurrentProgressInPercent(goalMock, weightEntriesMock);
            
            // Assert
            Assert.That(progress, Is.EqualTo(0.5));
        }

        [Test]
        public void TargetWeight70StartWeight80CurrentWeight90ShouldReturn1xNegativeProgress()
        {
            // Assign
            var goalMock = new WeightGoal
            {
                CurrentWeight = 80,
                TargetWeight = 70,
                StartDate = new DateTime(2022, 1, 1),
                EndDate = new DateTime(2022, 2, 1)
            };

            var weightEntry = new WeightEntry
            {
                CurrentWeight = 78,
                EntryDateTime = new DateTime(2022, 1, 15)
            };

            var LastWeightEntry = new WeightEntry
            {
                CurrentWeight = 90,
                EntryDateTime = new DateTime(2022, 1, 20)
            };

            var weightEntriesMock = new List<IWeightEntry>
            {
               weightEntry,
               LastWeightEntry
            };

            var calculator = new WeightProgressCalculator();

            // Act
            var progress = calculator.CalculateCurrentProgressInPercent(goalMock, weightEntriesMock);

            // Assert
            Assert.That(progress, Is.EqualTo(-1));
        }

        [Test]
        public void TargetWeight90StartWeight80CurrentWeight90ShouldReturn1xPositiveProgress()
        {
            // Assign
            var goalMock = new WeightGoal
            {
                CurrentWeight = 80,
                TargetWeight = 90,
                StartDate = new DateTime(2022, 1, 1),
                EndDate = new DateTime(2022, 2, 1)
            };

            var weightEntry = new WeightEntry
            {
                CurrentWeight = 90,
                EntryDateTime = new DateTime(2022, 1, 15)
            };

            var weightEntriesMock = new List<IWeightEntry>
            {
               weightEntry
            };

            var calculator = new WeightProgressCalculator();

            // Act
            var progress = calculator.CalculateCurrentProgressInPercent(goalMock, weightEntriesMock);

            // Assert
            Assert.That(progress, Is.EqualTo(1));
        }

        [Test]
        public void TargetWeight100StartWeight90CurrentWeight95ShouldReturn80PositiveProgress()
        {
            // Assign
            var goalMock = new WeightGoal
            {
                CurrentWeight = 90,
                TargetWeight = 100,
                StartDate = new DateTime(2022, 1, 1),
                EndDate = new DateTime(2022, 2, 1)
            };

            var weightEntry = new WeightEntry
            {
                CurrentWeight = 98,
                EntryDateTime = new DateTime(2022, 1, 15)
            };

            var weightEntriesMock = new List<IWeightEntry>
            {
               weightEntry
            };

            var calculator = new WeightProgressCalculator();

            // Act
            var progress = calculator.CalculateCurrentProgressInPercent(goalMock, weightEntriesMock);

            // Assert
            Assert.That(progress, Is.EqualTo(0.8));
        }
    }
}