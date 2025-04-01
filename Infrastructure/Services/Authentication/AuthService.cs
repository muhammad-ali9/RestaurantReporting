using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Exceptions;
using Application.Interfaces.Authentication;
using Application.Interfaces.Context;
using Application.Response;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly IApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public AuthService(IApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var userExists = await _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(x => x.Email == request.Email); //Fetch all user data

            if (userExists == null)
            {
                throw new ApiExceptions($"User Not Found with Email {request.Email}");
            }
            if(!BCrypt.Net.BCrypt.Verify(request.Password, userExists.Password))
            {
                throw new ApiExceptions("Password is Incorrect");
            }

            JwtSecurityToken jwtToken = await GenerateToken(userExists);

            var response = new LoginResponse
            {
                UserEmail = userExists.Email,
                UserId = Convert.ToString(userExists.Id),
                JwtToken = new JwtSecurityTokenHandler().WriteToken(jwtToken)

            };
            return response;
        }

        public async Task<ApiResponse<string>> RegisterUser(RegisterRequest request)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Email == request.Email);

            if (userExists)
            {
                throw new ApiExceptions($"User with {request.Email} already exists");
            }
           var user =  new Users
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var basicRole = 2;
                
                var userRole = new UserRoles
                {
                    UserId = user.Id,
                    RoleId = basicRole
                };
            await _context.UserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();

            return new ApiResponse<string>("User Added Successfully");
        }
        public async Task<ApiResponse<string>> AddRoles(string roleName)
        {
            var roleExists = await _context.Roles.AnyAsync(r => r.RoleName == roleName);
            if (roleExists)
            {
                throw new ApiExceptions($"Role {roleName} already exists");
            }
            var newRole = new Roles
            {
                RoleName = roleName
            };
            await _context.Roles.AddAsync(newRole);
            await _context.SaveChangesAsync();
            return new ApiResponse<string>(newRole.RoleName, "Role Added Successfully");
        }
        private async Task<JwtSecurityToken> GenerateToken(Users userExists)
        {
            var userRoles = userExists.UserRoles.Select(x => x.Role.RoleName).ToList();

            var userClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userExists.FirstName + " " + userExists.LastName),
                new Claim(JwtRegisteredClaimNames.Email, userExists.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("userId", userExists.Id.ToString()),
                new Claim("firstName", userExists.FirstName),
                new Claim("lastName", userExists.LastName),
            };
            foreach (var role in userRoles)
            {
                userClaims.Add(new Claim("roles", role));
            }
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    issuer: jwtSettings["Issuer"],
                    audience: jwtSettings["Audience"],
                    claims: userClaims,
                    expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpirationMinutes"])),
                    signingCredentials: credentials
              );
            return token;
        }
    }
}
