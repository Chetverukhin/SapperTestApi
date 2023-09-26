using System.Text.Json.Serialization;

namespace SapperTest.Models
{
    public class TurnResponseModel
    {
        [JsonPropertyName("game_id")]
        public string GameId { get; set; }

        [JsonPropertyName("height")]
        public int Row { get; set; }

        [JsonPropertyName("width")]
        public int Col { get; set; }

        [JsonPropertyName("mines_count")]
        public int MinesCount { get; set; }
        public bool Completed { get; set; }
        public List<string[]> Field { get; set; }
    }
}
