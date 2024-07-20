namespace TheUnlimited_Backend_.ViewModels
{
    public class AgentDto
    {
        public int AgentID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ContactNumber { get; set; }
        public string AgentLevelDescription { get; set; }
        public string AgentStatusDescription { get; set; }
        public string OfficeLocation { get; set; }
        public string ScheduleDescription { get; set; }
        public string SalesChannelDescription { get; set; }
        public List<AuditTrailDto> AuditTrails { get; set; }
        public string UserName { get; set; }
        public int ? UplineID { get; set; }
        //public int ProductSalesID { get; set; }
        public List<ProductSalesDto> ProductSales { get; set; }
    }
}
