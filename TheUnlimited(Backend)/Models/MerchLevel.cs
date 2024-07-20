namespace TheUnlimited_Backend_.Models
{
    public class MerchLevel
    {
        public int MerchLevelID { get; set; }
        public string LevelDescription { get; set; }
        public ICollection<MerchCode> MerchCodes { get; set; }
    }
}
