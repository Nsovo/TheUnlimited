namespace TheUnlimited_Backend_.Models
{
    public class SalesChannel
    {
        public int SalesChannelID { get; set; }
        public string ChannelDescription { get; set; }
        public ICollection<ProductSales> ProductSales { get; set; }
        public ICollection<Agent> Agents { get; set; }
    }
}
