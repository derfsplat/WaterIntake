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

        static void Main(string[] args)
        {
            
            WaterIntake water = new WaterIntake(); // created variable 'water' of type 'waterintake' and initialized it as a new object
            Console.WriteLine("Program Started");

            aTimer = new System.Timers.Timer(5000);
            aTimer.Elapsed += OnHourInterval;
            aTimer.Enabled = true;

            int intake = 0;
            int total = 0;

            while (total < 65)
            {
            
            //Console.WriteLine("Please enter your water intake in ounces in the last hour: ");
            intake = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("You drank {0} ounce(s) in the past hour. \n", intake);

            water.AddOuncesDrank(intake); // method

            IntakeStastics stats = water.ComputeStatistics();

            total += intake;

            Messages message = water.DisplayMessage(stats);

            if (total < 64)
            { 
                Console.WriteLine(message.WaterIntakeSoFarMessage);
                Console.WriteLine(message.WaterIntakeUntilGoalMetMessage);
                Console.WriteLine();
            }

            if (total >= 64)
            {
                Console.WriteLine(message.GoalMetMessage);
                Console.WriteLine(message.IntakeInExcessOfGoal);

                aTimer.Enabled = false;
                SpeechSynthesizer x = new SpeechSynthesizer();                
                x.Speak("Nicely done.  Mission Accomplished.");
                
            }

            }

            
        }

        private static void OnHourInterval(object sender, ElapsedEventArgs e)
        {
            Console.Beep();
            Console.WriteLine("Please enter your water intake in ounces in the last hour: ", e.SignalTime);
            
        }

       
    }
}
