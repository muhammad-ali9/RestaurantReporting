using Application.Response;

namespace Application.Interfaces.Authentication
{
  public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task<ApiResponse<string>> RegisterUser(RegisterRequest request);
        Task<ApiResponse<string>> AddRoles(string roleName);
    }
}
