using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaterIntakeTracker
{
    public class Messages
    {

        public Messages(string waterIntakeSoFarMessage)
        {
            WaterIntakeSoFarMessage = waterIntakeSoFarMessage;
            WaterIntakeUntilGoalMetMessage = "he he";
            GoalMetMessage = "YOU DID IT!";
            IntakeInExcessOfGoal = "ho ho";
        }

        public string WaterIntakeSoFarMessage
        {
            get; 
            private set; 
        }
        public string WaterIntakeUntilGoalMetMessage;
        public string GoalMetMessage;
        public string IntakeInExcessOfGoal;
    }
}