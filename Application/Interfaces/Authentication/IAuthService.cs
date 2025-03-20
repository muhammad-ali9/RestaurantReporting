using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Application.Interfaces.Authentication
{
  public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest request);
        //Task<ApiResponse> Register(RegisterRequest request);
    }
}
