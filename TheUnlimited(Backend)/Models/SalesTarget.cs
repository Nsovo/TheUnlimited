namespace TheUnlimited_Backend_.Models
{
    public class SalesTarget
    {
        public int SalesTargetID { get; set; }
        public int AgentID { get; set; }
        public decimal TargetAmount { get; set; }
        public DateTime TargetDate { get; set; }
        public Agent Agent { get; set; }
    }
}
