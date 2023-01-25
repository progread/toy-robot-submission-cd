namespace PronamicsToyRobot.Classes
{
    public class Board
    {
        private const int DEFAULT_BOARD_SIZE = 5;

        public int Length { get; set; }
        public int Height { get; set; }

        public bool ValidPosition(int x, int y)
        {
            return x >= 0 && y >= 0 && x < Length && y < Height;
        }
        public bool ValidPosition(Coordinate c)
        {
            return ValidPosition(c.X, c.Y);
        }

        public static Board CreateDefaultBoard()
        {
            Board newBoard = new Board
            {
                Length = DEFAULT_BOARD_SIZE,
                Height = DEFAULT_BOARD_SIZE
            };

            return newBoard;
        }
    }
}
