﻿namespace Application.Interfaces.Authentication
{
    public class LoginResponse
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string JwtToken { get; set; }
        public string UserRole { get; set; }
        public string UserEmail { get; set; }

    }
}
