﻿namespace Models
{
    public class RouletteBet
    {
        public int RouletteId { get; set; }
        public int UserId { get; set; }
        public string NumberOrColorBet { get; set; }
        public decimal MoneyBet { get; set; }
    }
}
