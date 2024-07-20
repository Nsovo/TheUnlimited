namespace TheUnlimited_Backend_.Models
{
    public class Benefit
    {
        public int BenefitID { get; set; }
        public int PlanID { get; set; }
        public string BenefitDescription { get; set; }
        public Plan Plan { get; set; }
    }
}
