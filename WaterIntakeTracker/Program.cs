using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Speech.Synthesis;
using System.Timers;

namespace WaterIntakeTracker
{
    class Program
    {
        private static System.Timers.Timer aTimer;
        static WaterIntake water = new WaterIntake(); // created variable 'water' of type 'waterintake' and initialized it as a new object
        static int total = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Program Started");

            aTimer = new System.Timers.Timer(5000);
            aTimer.Elapsed += OnHourInterval;
            aTimer.Enabled = true;
            PromptForIntake(DateTime.Now);

            while (water.GoalReached == false)
            {
                
            }
        }



        private static void PromptForIntake(DateTime signalTime)
        {
            aTimer.Enabled = false;
            
            string input;
            do
            {
                Console.Beep();
                Console.WriteLine("Please enter your water intake in ounces in the last hour: ", signalTime);

                input = Console.ReadLine();
            } while (water.IsValidNumber(input) == false);

            int intake = Convert.ToInt32(input);

            Console.WriteLine("You drank {0} ounce(s) in the past hour. \n", intake);

            water.AddOuncesDrank(intake); // method

            IntakeStastics stats = water.ComputeStatistics();

            total += intake;
            
            //TODO: return a single string with the display message
            Messages message = water.DisplayMessage(stats);

            if(total < Constants.WaterIntakeGoal)
            {
                Console.WriteLine(message.WaterIntakeSoFarMessage);
                Console.WriteLine(message.WaterIntakeUntilGoalMetMessage);
                Console.WriteLine();
            }

            if(total >= Constants.WaterIntakeGoal)
            {
                Console.WriteLine(message.GoalMetMessage);
                Console.WriteLine(message.IntakeInExcessOfGoal);

                aTimer.Enabled = false;
                SpeechSynthesizer x = new SpeechSynthesizer();
                x.Speak("Nicely done.  Mission Accomplished.");
            }

            aTimer.Enabled = true;
        }

        private static void OnHourInterval(object sender, ElapsedEventArgs e)
        {
            PromptForIntake(e.SignalTime);
        }
    }
}
