namespace TheUnlimited_Backend_.ViewModels
{
    public class ProductSalesDto
    {
        public int ProductSalesID { get; set; }
        public int AgentID { get; set; }
        public int ProductID { get; set; }
        public decimal SalesAmount { get; set; }
        public DateTime SalesDate { get; set; }
        public int SalesChannelID { get; set; }
        //public AgentDto Agent { get; set; }
        //public Product Product { get; set; }
        //public SalesChannelDto SalesChannel { get; set; }

    }
}
