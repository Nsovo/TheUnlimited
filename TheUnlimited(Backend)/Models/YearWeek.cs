namespace TheUnlimited_Backend_.Models
{
    public class YearWeek
    {
        public int YearWeekID { get; set; }
        public int Year { get; set; }
        public int Week { get; set; }
        public ICollection<Commission> Commissions { get; set; }
    }
}
