﻿using TheUnlimited_Backend_.Models;

namespace TheUnlimited_Backend_.ViewModels
{
    public class UserDto
    {
    
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ContactNumber { get; set; }
        public int UserProfileID { get; set; }
        public string UserProfileDescription { get; set; }
        public List<AuditTrailDto> AuditTrails { get; set; }
        public int? AgentID { get; set; }
        public Agent? Agent { get; set; }
        public string? VerificationCode { get; set; }
        public DateTime? VerificationCodeExpiration { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
    }

}
