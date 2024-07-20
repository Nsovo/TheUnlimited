namespace TheUnlimited_Backend_.Models
{
    public class Reward
    {
        public int RewardID { get; set; }
        public int AgentID { get; set; }
        public int RewardTypeID { get; set; }
        public DateTime RewardDate { get; set; }
        public decimal RewardAmount { get; set; }
        public RewardType RewardType { get; set; }
        public Agent Agent { get; set; }
    }
}
