using System.Text.Json.Serialization;

namespace SapperTest.Mdels
{
    public class GameResponseModel
    {
        [JsonPropertyName("game_id")]
        public string GameId { get; set; }
        public int Width { get; set; }
        public int Heigth { get; set; }

        [JsonPropertyName("mines_count")]
        public int MinesCount { get; set; }
        public List<string[]> Field { get; set; }
    }
}
