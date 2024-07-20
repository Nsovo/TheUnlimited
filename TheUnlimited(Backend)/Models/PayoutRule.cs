namespace TheUnlimited_Backend_.Models
{
    public class PayoutRule
    {
        public int PayoutRuleID { get; set; }
        public string RuleDescription { get; set; }
        public decimal PayoutPercentage { get; set; }
        public ICollection<Commission> Commissions { get; set; }
    }
}
