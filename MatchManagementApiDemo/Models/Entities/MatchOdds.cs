using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchManagementApiDemo.Models
{
    /// <summary>
    /// Represents the odds associated with a match, including details such as ID, match ID, specifier, and odd value.
    /// </summary>
    public class MatchOdds
    {
        /// <summary>
        /// Gets or sets the unique identifier for the odds entry.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the match associated with the odds.
        /// </summary>
        public int MatchId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for the associated match.
        /// </summary>
        public Match Match { get; set; }

        /// <summary>
        /// Gets or sets the specifier for the odds entry.
        /// </summary>
        public string Specifier { get; set; }

        /// <summary>
        /// Gets or sets the decimal value representing the odds.
        /// </summary>
        public decimal Odd { get; set; }
    }
}
