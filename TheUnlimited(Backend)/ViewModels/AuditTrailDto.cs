namespace TheUnlimited_Backend_.ViewModels
{
    public class AuditTrailDto
    {
        public DateTime LoginTimestamp { get; set; }
        public DateTime? LogoutTimestamp { get; set; }
    }
}
