using System;
using System.Collections.Generic;

namespace WaterIntakeTracker
{
    public class WaterIntake // a class can be used to create a type that a variable can use
    {
        List<int> ounces = new List<int>(); // created variable ounces with list type (from System.Collections.Generic) and initialized an instance list object

        public void AddOuncesDrank(int oz) // behavior method defintion.  i can only use paramter ounces anywhere within this method
        {
            ounces.Add(oz); //code that executes when method is called  
        }

        public int TotalConsumed
        {
            get 
            { 
               IntakeStastics stats = ComputeStatistics();  // get ouncesconsumed
               return stats.OuncesConsumed;
            }
        }

        public IntakeStastics ComputeStatistics()
        {
            IntakeStastics x = new IntakeStastics();

            int intake = 0;

            foreach (int oz in ounces)
            {
                intake += oz;
            }

            x.OuncesConsumed += intake;
            x.OuncesRemaining -= intake;

            if (x.OuncesRemaining < 0) 
            {
                x.OuncesInExcessOfGoal = x.OuncesRemaining * -1;
                x.OuncesRemaining = 0;
            }

            return x;
            
         
        }

       
        //TODO: needs a test!
        public bool IsValidNumber(string input)
        {
            int number;
            return int.TryParse(input, out number);
        }

        public Messages DisplayMessage(IntakeStastics stats)
        {
            Messages message = new Messages(
                waterIntakeSoFarMessage:
                    string.Concat("You have consumed ", stats.OuncesConsumed, " ounce(s) of water today.")
                );
            
            {
                message.WaterIntakeUntilGoalMetMessage = string.Concat("You need to drink  ", stats.OuncesRemaining, " more ounce(s) to meet daily goal!");
                message.IntakeInExcessOfGoal = string.Concat("You surpassed your goal by ", stats.OuncesInExcessOfGoal, " ounce(s)!");

            }
            
            return message;
        }


        public bool GoalReached
        {
            get
            {
                var stats = ComputeStatistics();
                return stats.OuncesConsumed >= Constants.WaterIntakeGoal;
            }
        }
    }
}
