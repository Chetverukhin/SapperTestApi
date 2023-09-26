namespace SapperTest.Data
{
    public class Game
    {
        public Game(int row, int col, int minesCount) 
        {
            GameId = Guid.NewGuid().ToString();
            Row = row;
            Col = col;
            MinesCount = minesCount;
            Completed = false;
            Win = false;
            Field = new string[row, col];
            NumberMap = new int[row, col];
            MinesMap = new string[row, col];
        }

        public string GameId { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public int MinesCount { get; set; }
        public bool Completed { get; set; }
        public bool Win { get; set; }
        public string[,] Field { get; set; }
        public int[,] NumberMap{ get; set; }
        public string[,] MinesMap { get; set; }
    }
}
