namespace TheUnlimited_Backend_.Models
{
    public class Schedule
    {
        public int ScheduleID { get; set; }
        public string Description { get; set; }
        public ICollection<Agent> Agents { get; set; }
    }
}
