using MatchManagementApiDemo.Converters;
using MatchManagementApiDemo.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchManagementApiDemo.Models
{
    /// <summary>
    /// Represents a match entity with details such as ID, description, date, time, teams, and sport type.
    /// </summary>
    public class Match
    {
        /// <summary>
        /// Gets or sets the unique identifier for the match.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the description of the match.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the date of the match.
        /// </summary>
        //[JsonConverter(typeof(DateFormatConverter))]
        public DateTime MatchDate { get; set; }

        /// <summary>
        /// Gets or sets the time of the match.
        /// </summary>
        //[JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan MatchTime { get; set; }

        /// <summary>
        /// Gets or sets the collection of odds associated with this match.
        /// </summary>
        public List<MatchOdds> MatchOdds { get; set; }

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
    }
}
