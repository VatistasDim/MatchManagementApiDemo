using MatchManagementApiDemo.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchManagementApiDemo.Models.DTO
{
    public class MatchDto
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime MatchDate { get; set; }
        public TimeSpan MatchTime { get; set; }
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public SportType Sport { get; set; }
        public List<MatchOddsDto> MatchOdds { get; set; }
    }
}
