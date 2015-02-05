using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WaterIntakeTracker.Tests
{
    [TestClass]
    public class WaterIntakeTrackerTests
    {
        [TestMethod]
        public void CalculateOuncesConsumed()
        {
            WaterIntake water = new WaterIntake();

            water.AddOuncesDrank(15);
            water.AddOuncesDrank(20);
            water.AddOuncesDrank(3);

            IntakeStastics stats = water.ComputeStatistics();

            Assert.AreEqual(38, stats.OuncesConsumed);

        }

        [TestMethod]
        public void CalculateOuncesRemaining()
        {
            WaterIntake water = new WaterIntake();

            water.AddOuncesDrank(11);
            water.AddOuncesDrank(5);

            IntakeStastics stats = water.ComputeStatistics();

            Assert.AreEqual(48, stats.OuncesRemaining);
        }

        [TestMethod]
        public void PrintWaterIntakeSoFarMessage()
        {
            WaterIntake water = new WaterIntake();

            water.AddOuncesDrank(25);
            water.AddOuncesDrank(20);

            var stats = water.ComputeStatistics();

            var message = water.DisplayMessage(stats);

            Assert.AreEqual("You have consumed 45 ounce(s) of water today.", message.WaterIntakeSoFarMessage);
        }

        [TestMethod]
        public void GivenIntakeReachesGoal_GoalReachedIsTrue()
        {
            WaterIntake water = new WaterIntake();
            water.AddOuncesDrank(Constants.WaterIntakeGoal);

            var goalReached = water.GoalReached;
            
            Assert.IsTrue(goalReached);
        }

        [TestMethod]
        public void GivenIntakeNotReachedGoal_GoalReachedIsFalse()
        {
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void GivenIncreaseInIntake_TotalConsumedIncreasesByIntakeAmount()
        {
            var water = new WaterIntake();

            water.AddOuncesDrank(56);
            water.AddOuncesDrank(5);

            Assert.AreEqual(61, water.TotalConsumed);
        }
    }
}