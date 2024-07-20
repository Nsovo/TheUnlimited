namespace TheUnlimited_Backend_.Models
{
    public class Hierarchy
    {
        public int HierarchyID { get; set; }
        public int ParentMerchCode { get; set; }
        public string ParentName { get; set; }
        public int ParentLevelID { get; set; }
        public double TTB { get; set; }
        public double DialTime { get; set; }

        public ParentLevel ParentLevel { get; set; }

        public int AgentID { get; set; }
        public Agent Agent { get; set; }
    }
}
