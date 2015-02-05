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
            IntakeStastics stats = new IntakeStastics();
            Messages message = new Messages();

            water.AddOuncesDrank(25);
            water.AddOuncesDrank(20);

            stats = water.ComputeStatistics();

            message = water.DisplayMessage(stats);

            Assert.AreEqual("You have consumed 45 ounces of water today.", message.WaterIntakeSoFarMessage);
        }
    }
}