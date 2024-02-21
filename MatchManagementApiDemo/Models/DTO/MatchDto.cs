using MatchManagementApiDemo.Converters;
using MatchManagementApiDemo.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MatchManagementApiDemo.Models.DTO
{
    /// <summary>
    /// Represents the data transfer object (DTO) for a match.
    /// </summary>
    public class MatchDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the match.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the description of the match.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the date of the match.
        /// </summary>
        [JsonConverter(typeof(DateFormatConverter))]
        public DateTime MatchDate { get; set; }

        /// <summary>
        /// Gets or sets the time of the match.
        /// </summary>
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan MatchTime { get; set; }

        /// <summary>
        /// Gets or sets the name of Team A participating in the match.
        /// </summary>
        public string TeamA { get; set; }

        /// <summary>
        /// Gets or sets the name of Team B participating in the match.
        /// </summary>
        public string TeamB { get; set; }

        /// <summary>
        /// Gets or sets the type of sport for the match.
        /// </summary>
        public SportType Sport { get; set; }

        /// <summary>
        /// Gets or sets the list of match odds associated with the match.
        /// </summary>
        public List<MatchOddsDto> MatchOdds { get; set; }
    }
}
