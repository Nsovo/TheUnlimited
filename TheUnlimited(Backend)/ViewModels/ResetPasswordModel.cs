﻿namespace TheUnlimited_Backend_.ViewModels
{
    public class ResetPasswordModel
    {
        public string UserName { get; set; }
        public string VerificationCode { get; set; }
        public string NewPassword { get; set; }
    }
}
