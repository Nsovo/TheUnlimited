namespace TheUnlimited_Backend_.Models
{
    public class UserProfile
    {
        public int? UserProfileID { get; set; }
        public string? ProfileDescription { get; set; }
        public ICollection<User> Users { get; set; }
    }
}