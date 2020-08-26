using System;

namespace Models
{
    public class RouletteDto
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
    }
}
