using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace TheUnlimited_Backend_.Models
{
    public class User : IdentityUser
    {

        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? ContactNumber { get; set; }
        public int UserProfileID { get; set; }
        public UserProfile? UserProfile { get; set; }
        public ICollection<AuditTrail> AuditTrails { get; set; }

        // Foreign key and navigation property for Agent
        public int? AgentID { get; set; }
        public Agent? Agent { get; set; }

        // Fields for verification code and expiration time
        public string? VerificationCode { get; set; }
        public DateTime? VerificationCodeExpiration { get; set; }
    }
}