namespace TheUnlimited_Backend_.Models
{
    public class TestAccess
    {
        public int TestID { get; set; }
        public Test Test { get; set; }
        public int AgentLevelID { get; set; }
        public AgentLevel AgentLevel { get; set; }
    }
}
