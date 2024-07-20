namespace TheUnlimited_Backend_.Models
{
    public class RewardType
    {
        public int RewardTypeID { get; set; }
        public string TypeDescription { get; set; }
        public ICollection<Reward> Rewards { get; set; }
    }
}
