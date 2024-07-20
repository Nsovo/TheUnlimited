namespace TheUnlimited_Backend_.ViewModels
{
    public class CreateAgentDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? ContactNumber { get; set; }
        public int AgentLevelID { get; set; }
        public DateTime AgentStartDate { get; set; }
        public int AgentStatusID { get; set; }
        public int? OfficeCode { get; set; }
        public DateTime? AgentTerminationDate { get; set; }
        //public string? UplineName { get; set; }
        public int? ScheduleID { get; set; }
        public int SalesChannelID { get; set; }

        // User details
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int UserProfileID { get; set; }
    }
}
