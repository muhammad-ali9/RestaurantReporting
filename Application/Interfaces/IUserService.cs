using Application.DTOs;

namespace Application.Services
{
   public interface IUserService
    {
        Task<List<UserDetailsDto>> GetAllUsersAsync();
        Task<string> AssignRole(int id, string role);
    }
}
