namespace TheUnlimited_Backend_.Models
{
    public class OwnerType
    {
        public int OwnerTypeID { get; set; }
        public string TypeDescription { get; set; }
        public ICollection<Owner> Owners { get; set; }
    }
}
