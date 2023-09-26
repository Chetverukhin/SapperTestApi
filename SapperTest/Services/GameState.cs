using SapperTest.Data;
using SapperTest.Models;

namespace SapperTest.Services
{
    public static class GameState
    {
        public static bool ClearedMines(this Game game)
        {
            var defaultCell = 0;
            for (int i = 0; i < game.Row; i++)
            {
                for (int j = 0; j < game.Col; j++)
                {
                    if (game.Field[i, j] == CellCovers.Default)
                    {
                        defaultCell++;
                    }
                }
            }

            return defaultCell == game.MinesCount;
        }

        public static bool CatchMine(this Game game, int rowCoord, int colCoord)
        {
            return game.MinesMap[rowCoord, colCoord] == CellCovers.Mine;
        }

        public static bool IsInBorder(this Game game, int rowCoord, int colCoord)
        {
            if (rowCoord < 0 || colCoord < 0 || colCoord > game.Col - 1 || rowCoord > game.Row - 1)
            {
                return false;
            }
            return true;
        }
    }
}
