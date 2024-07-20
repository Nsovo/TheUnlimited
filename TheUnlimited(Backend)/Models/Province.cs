namespace TheUnlimited_Backend_.Models
{
    public class Province
    {
        public int ProvinceID { get; set; }
        public string ProvinceName { get; set; }
        public ICollection<OfficeProvince> OfficeProvinces { get; set; }
    }
}
