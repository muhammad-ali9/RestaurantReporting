using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces.Context;
using Application.Services;
using Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
     
        private readonly IApplicationDbContext _context;
        public UserService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> AssignRole(int id, string role)
        {
           var user = _context.Users.Find(id);
            var roleExists = await _context.Roles.FirstOrDefaultAsync(u => u.RoleName == role);

            if(roleExists == null)
            {
                throw new ApiExceptions("Role Does Not Exists");
            }

            var userRoleExists = await _context.UserRoles
                .AnyAsync(r => r.UserId == id && r.RoleId == roleExists.Id);

            if (userRoleExists)
            {
                throw new ApiExceptions("User already Have this Role");
            }

            var userRole = new UserRoles
            {
                UserId = id,
                RoleId = roleExists.Id
            };

            _context.UserRoles.Add(userRole);
            await _context.SaveChangesAsync();

            return $"User Role '{role}' Assign Succesfully ";
        }

        public async Task<List<UserDetailsDto>> GetAllUsersAsync()
        {
            var adminRole = "SuperAdmin";
            var query = @"
                        SELECT 
                            u.Id AS UserId, u.FirstName + ' ' + u.LastName AS UserName, 
                            u.Email, 
                            r.RoleName AS UserRoles 
                        FROM Users u
                        JOIN UserRoles ur ON u.Id = ur.UserId
                        JOIN Roles r ON ur.RoleId = r.Id
                        WHERE r.RoleName != @RoleName";

            try
            {
                var users = await _context.Database
                    .SqlQueryRaw<UserDetailsDto>(query, new SqlParameter("@RoleName", adminRole))
                    .ToListAsync();

                return users;
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error in GetAllUserQueryHandler", e);
            }
           

            
        }
        
    }
}
