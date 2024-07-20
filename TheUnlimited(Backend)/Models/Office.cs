using System.ComponentModel.DataAnnotations;

namespace TheUnlimited_Backend_.Models
{
    public class Office
    {
        [Key]
        public int OfficeId { get; set; }
        public int? OfficeCode { get; set; }
        public string? OfficeLocation { get; set; }
        public int? OwnerID { get; set; }

        public Owner Owner { get; set; }
        public ICollection<Agent> Agents { get; set; }
        public ICollection<OfficeProvince> OfficeProvinces { get; set; }
    }
}
