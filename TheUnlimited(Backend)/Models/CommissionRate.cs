namespace TheUnlimited_Backend_.Models
{
    public class CommissionRate
    {
        public int CommissionRateID { get; set; }
        public int ProductID { get; set; }
        public decimal Rate { get; set; }
        public Product Product { get; set; }
    }
}
