namespace PronamicsToyRobot.Classes
{
    public class Coordinate
    {
        public int X { get; set; } // Positive = East
        public int Y { get; set; } // Positive = North

        public Coordinate()
        {
            X = 0;
            Y = 0;
        }
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Coordinate(Coordinate c)
        {
            X = c.X;
            Y = c.Y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
