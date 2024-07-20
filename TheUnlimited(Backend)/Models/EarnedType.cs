namespace TheUnlimited_Backend_.Models
{
    public class EarnedType
    {
        public int? EarnedTypeID { get; set; }
        public string? Description { get; set; }
        public ICollection<Commission> Commissions { get; set; }
    }
}
