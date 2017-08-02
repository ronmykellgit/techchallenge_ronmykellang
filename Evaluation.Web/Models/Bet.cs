namespace Evaluation.Web.Models
{
    public class Bet
    {
        public int CustomerId { get; set; }
        public int RaceId { get; set; }
        public int HorseId { get; set; }
        public decimal ReturnStake { get; set; }
        public bool Won { get; set; }
    }
}