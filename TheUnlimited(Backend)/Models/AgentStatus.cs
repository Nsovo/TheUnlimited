namespace TheUnlimited_Backend_.Models
{
    public class AgentStatus
    {
        public int AgentStatusID { get; set; }
        public string StatusDescription { get; set; }
        public ICollection<Agent> Agents { get; set; }
        public ICollection<Commission> Commissions { get; set; }
    }
}
