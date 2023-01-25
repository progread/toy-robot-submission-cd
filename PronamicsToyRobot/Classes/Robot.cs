namespace PronamicsToyRobot.Classes
{
    public class Robot
    {
        private bool isPlaced = false; 

        public Coordinate Position { get; set; }
        public Facing Direction { get; set; }

        public void Place(int x, int y, Facing direction)
        {
            isPlaced = true;
            Position = new Coordinate(x, y);
            Direction = direction;
        }

        public bool Move(Board b)
        {
            if (!CanReceiveCommands()) return false;

            bool finishedMove = false;
            Coordinate nextPosition = new Coordinate(Position);
            switch (Direction) // Reminder: Up and Right are positive coordinates. 
            {
                case Facing.North:
                    nextPosition.Y += 1;
                    break;
                case Facing.East:
                    nextPosition.X += 1;
                    break;
                case Facing.West:
                    nextPosition.X -= 1;
                    break;
                default: // South
                    nextPosition.Y -= 1;
                    break;
            }

            if (b.ValidPosition(nextPosition))
            {
                Position = new Coordinate(nextPosition);
                finishedMove = true;
            }

            return finishedMove;
        }

        /// <summary>
        /// Rotate the direction. North = 0, West = 3.
        /// </summary>
        public void Turn(bool clockwise)
        {
            if (!CanReceiveCommands()) return;

            int direction = clockwise ? 1 : -1;
            Direction += direction;
            if (Direction < Facing.North) Direction = Facing.West;
            else if (Direction > Facing.West) Direction = Facing.North;
        }

        public string Report()
        {
            if (!CanReceiveCommands()) return null;
            return $"{Position} {Direction.ToString().ToUpper()}";
        }

        /// <summary>
        /// Set as a method just in case we would want to add other constraints, 
        /// such as being 'stunned' or if there are multiple robots. 
        /// </summary>
        private bool CanReceiveCommands()
        {
            return isPlaced;
        }
    }
}
