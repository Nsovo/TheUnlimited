namespace TheUnlimited_Backend_.Models
{
    public class CommissionStatus
    {
        public int CommissionStatusID { get; set; }
        public string Description { get; set; }

        public ICollection<Commission> Commissions { get; set; }
    }
}
