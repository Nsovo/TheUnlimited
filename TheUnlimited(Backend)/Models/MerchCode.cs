namespace TheUnlimited_Backend_.Models
{
    public class MerchCode
    {
        public int MerchCodeID { get; set; }
        public string Code { get; set; }
        public int MerchLevelID { get; set; }
        public MerchLevel MerchLevel { get; set; }
    }
}
