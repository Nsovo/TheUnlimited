namespace TheUnlimited_Backend_.Models
{
    public class OfficeProvince
    {
        public int? OfficeCode { get; set; }
        public Office? Office { get; set; }
        public int? ProvinceID { get; set; }
        public Province? Province { get; set; }
    }
}
