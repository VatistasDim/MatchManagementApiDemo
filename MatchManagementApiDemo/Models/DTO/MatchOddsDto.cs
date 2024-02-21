using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchManagementApiDemo.Models.DTO
{
    public class MatchOddsDto
    {
        public int ID { get; set; }
        public string Specifier { get; set; }
        public decimal Odd { get; set; }
    }
}
