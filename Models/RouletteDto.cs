using System;
using System.Collections.Generic;

namespace Models
{
    public class RouletteDto
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public List<RouletteBet> RouletteBets { get; set; }
    }
}
