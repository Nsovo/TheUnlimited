namespace TheUnlimited_Backend_.Models
{
    public class Promotion
    {
        public int PromotionID { get; set; }
        public int AgentID { get; set; }
        public DateTime PromotionDate { get; set; }
        public string PromotionDetails { get; set; }
        public Agent Agent { get; set; }
    }
}
