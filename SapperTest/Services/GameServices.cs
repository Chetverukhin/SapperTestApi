using SapperTest.Data;
using SapperTest.Models;

namespace SapperTest.Services
{
    public static class GameServices
    {
        public static void End(this Game game) 
        {
            if (game.ClearedMines())
            {
                game.Win = true;
            }

            game.Completed = true;
            game.SetEndGameField();
        }


        public static List<string[]> CreateResponseField(string[,] field)
        {
            var responseList = new List<string[]>();

            for (int i = 0; i < field.GetLength(0); i++)
            {
                string[] row = new string[field.GetLength(1)];
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    row[j] = field[i, j];
                }

                responseList.Add(row);
            }

            return responseList;
        }

        public static void SetEndGameField(this Game game) 
        {
            for (int i = 0; i < game.Row; i++)
            {
                for (int j = 0; j < game.Col; j++)
                {
                    game.OpenCell(i, j);
                }
            }
        }

        private static void OpenCell(this Game game, int rowCoord, int colCoord)
        {
            var mineCover = game.Win ? CellCovers.ClearedMine : CellCovers.Mine;

            game.Field[rowCoord, colCoord] = game.MinesMap[rowCoord, colCoord] == CellCovers.Mine
                        ? mineCover
                        : game.NumberMap[rowCoord, colCoord].ToString();
        }

        public static void OpenCells(this Game game, int rowCoord, int colCoord)
        {
            game.OpenCell(rowCoord, colCoord);

            if (game.NumberMap[rowCoord, colCoord] > 0)
            {
                return;
            }

            for (int k = rowCoord - 1; k < rowCoord + 2; k++)
            {
                for (int l = colCoord - 1; l < colCoord + 2; l++)
                {
                    if (!game.IsInBorder(k, l))
                    {
                        continue;
                    }
                    if (game.Field[k, l] != CellCovers.Default)
                    {
                        continue;
                    }
                    if (game.NumberMap[k, l] == 0)
                    {
                        game.OpenCells(k, l);
                    }
                    if (game.NumberMap[k, l] > 0 && game.MinesMap[k, l] != CellCovers.Mine)
                    {
                        game.OpenCell(k, l);
                    }
                }
            }
        }

        public static bool IsOpenCell(this Game game, int rowCoord, int colCoord)
        {
            return game.Field[rowCoord, colCoord] != CellCovers.Default;
        }
    }
}
