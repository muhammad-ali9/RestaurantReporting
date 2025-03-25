using System.Security.Claims;
using Application.Interfaces;

namespace WebApi.SharedServices
{
    public class LoggedInUser : ILoggedInUser
    {
        public LoggedInUser(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext.User.FindFirstValue("userId");
        }
        public string UserId { get; set; }
    }
}
