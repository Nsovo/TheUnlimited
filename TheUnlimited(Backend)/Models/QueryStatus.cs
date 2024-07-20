namespace TheUnlimited_Backend_.Models
{
    public class QueryStatus
    {
        public int QueryStatusID { get; set; }
        public string StatusName { get; set; }
        public ICollection<Query> Queries { get; set; }
    }
}
