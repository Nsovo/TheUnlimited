namespace TheUnlimited_Backend_.Models
{
    public class Owner
    {
        public int OwnerID { get; set; }
        public string OwnerName { get; set; }
        public int OwnerTypeID { get; set; }
        public OwnerType OwnerType { get; set; }
        public ICollection<Office> Offices { get; set; }
    }
}
