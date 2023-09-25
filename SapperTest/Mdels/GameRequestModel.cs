﻿using System.Text.Json.Serialization;

namespace SapperTest.Mdels
{
    public class GameRequestModel
    {
        public int Width { get; set; }
        public int Height{ get; set; }

        [JsonPropertyName("mines_count")]
        public int MinesCount { get; set; }
    }
}
