namespace TheUnlimited_Backend_.Models
{
    public class AgentLevel
    {
        public int AgentLevelID { get; set; }
        public string LevelDescription { get; set; }
        public ICollection<Agent> Agents { get; set; }
        public ICollection<TestAccess> TestAccesses { get; set; }
        public ICollection<Commission> Commissions { get; set; }
    }
}