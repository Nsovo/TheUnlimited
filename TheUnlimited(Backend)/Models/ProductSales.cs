namespace TheUnlimited_Backend_.Models
{
    public class ProductSales
    {
        public int ProductSalesID { get; set; }
        public int AgentID { get; set; }
        public int ProductID { get; set; }
        public decimal SalesAmount { get; set; }
        public DateTime SalesDate { get; set; }
        public int SalesChannelID { get; set; }
        public Agent Agent { get; set; }
        public Product Product { get; set; }
        public SalesChannel SalesChannel { get; set; }
        public ICollection<Commission> Commissions { get; set; }
    }
}
