using System.Text.Json.Serialization;

namespace SapperTest.Mdels
{
    public class TurnRequestModel
    {
        [JsonPropertyName("game_id")]
        public string GameId { get; set; }
        public int Col { get; set; }
        public int Row { get; set; }
    }
}
