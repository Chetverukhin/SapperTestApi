namespace SapperTest.Data
{
    public class Game
    {
        public string GameId { get; set; }
        public int Width { get; set; }
        public int Heigth { get; set; }
        public int MinesCount { get; set; }
        public bool Completed { get; set; }
        public string[,] Field { get; set; }
    }
}
