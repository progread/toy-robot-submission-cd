using PronamicsToyRobot.Classes;
using System;

namespace PronamicsToyRobot
{
    /// <summary>
    /// Toy Robot exercise 
    /// by Courtney Dawson 
    /// 
    /// 24/01/2023
    /// 
    /// Although there are some input errors reported back to the user, it was 
    /// decided not to actively log the robot receiving and responding to
    /// the user's commands as REPORT is the only command expecting an output. 
    /// </summary>
    internal class Program
    {
        private static Controller toyRobotController = new Controller();

        static void Main(string[] args)
        {
            ResetRobot();
            StartDemo();
        }

        public static void StartDemo()
        {
            bool running = true;
            string input = "";
            while (running) {
                Console.WriteLine("Congratulations on your robot toy. Please input your choice:");
                Console.WriteLine("");
                Console.WriteLine("1: Run the three preset tests.");
                Console.WriteLine("2: Manual test.");
                Console.WriteLine("Q: End the application.");

                input = Console.ReadLine().ToUpper();
                switch (input)
                {
                    case "1":
                        RunTests();
                        break;
                    case "2":
                        ManualTest();
                        break;
                    case "Q":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input. ");
                        break;
                }
            };

            Console.WriteLine("Robot toy test application ended. ");
            Console.ReadLine();
        }

        private static void ResetRobot()
        {
            toyRobotController = new Controller();
            toyRobotController.ReportAction = Console.WriteLine;
        }

        private static void RunTests()
        {
            Console.WriteLine("Test A: Should report (0,1) NORTH");
            ResetRobot();
            toyRobotController.CommandRobot("PLACE 0,0,NORTH");
            toyRobotController.CommandRobot("MOVE");
            toyRobotController.CommandRobot("REPORT");

            Console.WriteLine("Test B: Should report (0,0) WEST");
            ResetRobot();
            toyRobotController.CommandRobot("PLACE 0,0,NORTH");
            toyRobotController.CommandRobot("LEFT");
            toyRobotController.CommandRobot("REPORT");

            Console.WriteLine("Test C: Should report (3,3) NORTH");
            ResetRobot();
            toyRobotController.CommandRobot("PLACE 1,2,EAST");
            toyRobotController.CommandRobot("MOVE");
            toyRobotController.CommandRobot("MOVE");
            toyRobotController.CommandRobot("LEFT");
            toyRobotController.CommandRobot("MOVE");
            toyRobotController.CommandRobot("REPORT");
        }

        private static void ManualTest()
        {
            Console.WriteLine("Beginning manual mode. Type END to stop.");
            ResetRobot();

            bool running = true;
            while (running)
            {
                string input = Console.ReadLine().ToUpper();

                if (input.Equals("END")) running = false;
                else toyRobotController.CommandRobot(input);
            }
        }
    }
}
