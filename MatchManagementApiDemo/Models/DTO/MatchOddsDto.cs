using System.Text.Json.Serialization;

namespace MatchManagementApiDemo.Models.DTO
{
    public class MatchOddsDto
    {
        public int ID { get; set; }
        public int MatchId { get; set; }
        [JsonIgnore]
        public MatchDto Match { get; set; }
        public string Specifier { get; set; }
        public decimal Odd { get; set; }
    }
}
