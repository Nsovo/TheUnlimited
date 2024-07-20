namespace TheUnlimited_Backend_.Models
{
    public class Help
    {
        public int HelpID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int HelpCategoryID { get; set; }
        public HelpCategory HelpCategory { get; set; }
    }
}
