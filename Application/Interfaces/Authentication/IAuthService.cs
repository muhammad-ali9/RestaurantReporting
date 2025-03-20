using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Response;
using Microsoft.Extensions.Logging;

namespace Application.Interfaces.Authentication
{
  public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task<ApiResponse<string>> Register(RegisterRequest request);
        Task<ApiResponse<string>> AddRoles(string roleName);
    }
}
