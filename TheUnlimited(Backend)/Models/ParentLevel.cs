namespace TheUnlimited_Backend_.Models
{
    public class ParentLevel
    {
        public int ParentLevelID { get; set; }
        public string Description { get; set; }
        public ICollection<Hierarchy> Hierarchies { get; set; }
    }
}
