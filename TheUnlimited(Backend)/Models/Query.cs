namespace TheUnlimited_Backend_.Models
{
    public class Query
    {
        public int QueryID { get; set; }
        public int AgentID { get; set; }
        public string QueryText { get; set; }
        public int QueryStatusID { get; set; }
        public DateTime QueryDate { get; set; }
        public Agent Agent { get; set; }
        public QueryStatus QueryStatus { get; set; }
    }
}
