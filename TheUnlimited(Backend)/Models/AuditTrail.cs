namespace TheUnlimited_Backend_.Models
{
    public class AuditTrail
    {
        public int AuditTrailID { get; set; }
        public string UserID { get; set; }
        public string Action { get; set; }
        public DateTime? LoginTimestamp { get; set; }
        public DateTime? LogoutTimestamp { get; set; }
        public User Users { get; set; }

        // Add AgentID to track agent activities
        public int? AgentID { get; set; }
        public Agent Agent { get; set; }
    }
}
