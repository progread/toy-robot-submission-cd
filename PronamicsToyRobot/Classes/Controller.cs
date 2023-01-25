using System;

namespace PronamicsToyRobot.Classes
{
    /// <summary>
    /// The controller class is where the user's input is filtered to, but it 
    /// is also the monitor of the board and robot. 
    /// 
    /// The reason for this is due for extensibility: should we want the robot 
    /// to pick up or put down objects, or have multiple robots, the controller
    /// would be a good starting point for tracking multiple objects. 
    /// </summary>
    public class Controller
    {
        private Robot myRobot;
        private Board myBoard;


        public Action<string> ReportAction { get; set; } 

        public Controller() { 
            myRobot = new Robot();
            myBoard = Board.CreateDefaultBoard();
        }

        public void CommandRobot(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                Report("Ignored");
                return;
            }
            string[] commandSplit = command.Split(' ');
            string commandKeyword = commandSplit[0];

            switch (commandKeyword)
            {
                case "PLACE":
                    if (commandSplit.Length > 1)
                        PlaceRobot(commandSplit[1]);
                    break;
                case "MOVE":
                    MoveRobot();
                    break;
                case "RIGHT":
                    myRobot.Turn(true);
                    break;
                case "LEFT":
                    myRobot.Turn(false);
                    break;
                case "REPORT":
                    Report(myRobot.Report());
                    break;
                default:
                    break;
            }
        }

        private void PlaceRobot(string command)
        {

            string[] commandVariables = command.Split(',');
            if (commandVariables.Length < 3) {
                Report("Invalid placement: Must be in format \"PLACE X,Y,F\"");
                return;
            }

            int x, y;
            Facing facing;

            bool xParsed = int.TryParse(commandVariables[0], out x);
            bool yParsed = int.TryParse(commandVariables[1], out y);
            bool facingParsed = Enum.TryParse(commandVariables[2], true, out facing);

            if (!xParsed) Report("Invalid X coordinate");
            if (!yParsed) Report("Invalid Y coordinate");
            if (!facingParsed) Report("Invalid facing");

            if (xParsed && yParsed && facingParsed && myBoard.ValidPosition(x, y))
                myRobot.Place(x, y, facing);
        }

        /// <summary>
        /// For now it's enough to just let the robot validate its future 
        /// coordinates with the board, but if we were to implement obstacles
        /// then we might have to receive the predicted coordinates here and 
        /// validate it ourselves before calling Robot.Move. 
        /// </summary>
        private bool MoveRobot()
        {
            return myRobot.Move(myBoard);
        }

        private void Report(string message) {
            if (!string.IsNullOrWhiteSpace(message) && ReportAction != null) 
                ReportAction(message);
        }
    }
}
