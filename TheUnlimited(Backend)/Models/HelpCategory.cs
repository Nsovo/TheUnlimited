namespace TheUnlimited_Backend_.Models
{
    public class HelpCategory
    {
        public int HelpCategoryID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Help> Helps { get; set; }
    }
}
