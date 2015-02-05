using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaterIntakeTracker
{
    public class IntakeStastics
    {
        public IntakeStastics()
        {
           OuncesConsumed = 0;
           OuncesRemaining = 64;
           OuncesInExcessOfGoal = 0;
        }

        public int OuncesConsumed;
        public int OuncesRemaining;
        public int OuncesInExcessOfGoal;

    }
}
