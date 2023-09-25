using SapperTest.Data;

namespace SapperTest.Services
{
    public static class GameServices
    {
        public static void GetDefaultField(Game game)
        {
            for (int i = 0; i < game.Heigth; i++)
            {
                for (int j = 0; j < game.Width; j++)
                {
                    game.Field[i, j] = " ";
                }
            }
        }
        public static void SetMines(int minesCount, int width, int height)
        {
            var field = new string[width, height];
            var counter = 0;
            while (counter < minesCount)
            {
                var col = new Random().Next(0, width);
                var row = new Random().Next(0, height);

                if (field[col, row] != "X")
                {
                    field[col, row] = "X";
                    counter++;
                }
            }
        }
        public static void CountCellMines(int minesCount, int width, int height)
        {
            var field = new string[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (field[i, j] == "X")
                    {
                        for (int k = i - 1; k < i + 2; k++)
                        {
                            for (int l = j - 1; l < j + 2; l++)
                            {
                                if (!IsInBorder(width, height, k,l) || field[k,l] == "X")
                                {
                                    continue;
                                }

                                field[k,l] = field[k,l] + 1;
                            }
                        }
                    }
                }
            }
        }
        private static bool IsInBorder(int width, int height, int i, int j)
        {
            if (i < 0 || j < 0 || j > width - 1 || i > height - 1)
            {
                return false;
            }
            return true;
        }
    }
}
