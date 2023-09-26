using SapperTest.Data;
using SapperTest.Models;

namespace SapperTest.Services
{
    public static class GameInitialization
    {
        public static void Init(this Game game)
        {
            game.CreateField();
            game.SetMines();
            game.CreateNumberMap();
        }

        private static void CreateField(this Game game)
        {
            for (int i = 0; i < game.Row; i++)
            {
                for (int j = 0; j < game.Col; j++)
                {
                    game.Field[i, j] = CellCovers.Default;
                }
            }
        }

        private static void SetMines(this Game game)
        {
            var counter = 0;
            while (counter < game.MinesCount)
            {
                var row = new Random().Next(0, game.Row);
                var col = new Random().Next(0, game.Col);

                if (game.MinesMap[row, col] != CellCovers.Mine)
                {
                    game.MinesMap[row, col] = CellCovers.Mine;
                    counter++;
                }
            }
        }

        private static void CreateNumberMap(this Game game)
        {
            for (int i = 0; i < game.Row; i++)
            {
                for (int j = 0; j < game.Col; j++)
                {
                    if (game.MinesMap[i, j] == CellCovers.Mine)
                    {
                        for (int k = i - 1; k < i + 2; k++)
                        {
                            for (int l = j - 1; l < j + 2; l++)
                            {
                                if (!game.IsInBorder(k, l) || game.MinesMap[k, l] == CellCovers.Mine)
                                {
                                    continue;
                                }

                                game.NumberMap[k, l] = game.NumberMap[k, l] + 1;
                            }
                        }
                    }
                }
            }
        }
    }
}
