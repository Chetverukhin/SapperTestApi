namespace SapperTest.Services
{
    public class GameSetting
    {
        private static readonly int _maxFieldSize = 30;
        private static readonly int _minFieldSize = 5;
        private static readonly int _maxMineCount = 30;
        private static readonly int _minMineCount = 2;
        private static readonly float _coveredFieldMinesPercentage = 0.4f;
        private static int _suggestedMinesCount { get; set; }

        public static string CheckUserSettings(int width, int height, int minesCount)
        {
            var message = string.Empty;

            if (width > _maxFieldSize || height > _maxFieldSize)
            {
                message = $"Максимальный размер игрового поля {_maxFieldSize}*{_maxFieldSize} ячеек";
            }
            if (width < _minFieldSize || height < _minFieldSize)
            {
                message = $"Минимальный размер игрового поля {_minFieldSize}*{_minFieldSize} ячеек" ;
            }

            _suggestedMinesCount = (int)(width * height * _coveredFieldMinesPercentage);

            if (minesCount > _suggestedMinesCount)
            {
                message = $"Слишком большое количество мин, рекомендуем {_suggestedMinesCount}";            }

            if (minesCount > _maxMineCount)
            {
                message = $"Максимальное количество мин {_maxMineCount}";
            }
            if (minesCount < _minMineCount)
            {
                message = $"Минимальнок количество мин {_maxMineCount}";
            }           

            return message;
        }

    }
}
