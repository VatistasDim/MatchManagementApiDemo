using System.Text.Json.Serialization;

namespace MatchManagementApiDemo.Models.DTO
{
    /// <summary>
    /// Represents the data transfer object (DTO) for match odds.
    /// </summary>
    public class MatchOddsDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the match odds.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the match identifier associated with these odds.
        /// </summary>
        public int MatchId { get; set; }

        /// <summary>
        /// Gets or sets the reference to the associated match (ignored during serialization).
        /// </summary>
        [JsonIgnore]
        public MatchDto Match { get; set; }

        /// <summary>
        /// Gets or sets the specifier for the odds.
        /// </summary>
        public string Specifier { get; set; }

        /// <summary>
        /// Gets or sets the decimal value representing the odds.
        /// </summary>
        public decimal Odd { get; set; }
    }
}
