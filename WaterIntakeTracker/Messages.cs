using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaterIntakeTracker
{
    public class Messages
    {

        public Messages()
        {
            WaterIntakeSoFarMessage = "ha ha";
            WaterIntakeUntilGoalMetMessage = "he he";
            GoalMetMessage = "YOU DID IT!";
            IntakeInExcessOfGoal = "ho ho";
        }
        public string WaterIntakeSoFarMessage;
        public string WaterIntakeUntilGoalMetMessage;
        public string GoalMetMessage;
        public string IntakeInExcessOfGoal;
    }
}