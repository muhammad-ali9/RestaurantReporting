using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Services
{
    public class RestaurantTasks : IRestaurantTasks
    {
        private readonly IApplicationDbContext _context;
        private readonly ILoggedInUser _loggedInUser;
        private readonly IMemoryCache _memoryCache;
        public RestaurantTasks(IApplicationDbContext context, ILoggedInUser loggedInUser, IMemoryCache memoryCache)
        {
            _context = context;
            _loggedInUser = loggedInUser;
            _memoryCache = memoryCache;
        }


        public async Task<int> CreateRestaurantTaskAsync(RestaurantTasksDto restaurantTask)
        {
            var result = new Domain.RestaurantTasks()
            {
                SerialNoId = restaurantTask.SerialNo,
                FormId = restaurantTask.FormId,
                CityId = restaurantTask.CityId,
                CreatedBy = (int)Convert.ToInt64(_loggedInUser.UserId)

            };
            await _context.RestaurantTasks.AddAsync(result);
            await _context.SaveChangesAsync();
            return result.Id;
        }

        public async Task<List<UsersTaskDto>> GetUserTasksAsync()
        {

            var userId = (int)Convert.ToInt64(_loggedInUser.UserId);

            var cacheKey = $"user_tasks_{userId}";

            if (_memoryCache.TryGetValue(cacheKey, out List<UsersTaskDto>? cachedTasks))
            {
                return cachedTasks;
            }

            var userRoles = await (from ur in _context.UserRoles
                                   join r in _context.Roles on ur.RoleId equals r.Id
                                   where ur.UserId == userId
                                   select r.RoleName).ToListAsync();
            IQueryable<Domain.RestaurantTasks> query = _context.RestaurantTasks;

            if (userRoles.Contains("Inspector"))
            {
                query = query.Where(rt => rt.CreatedBy == userId);
            }

            var userTasks = await (from rt in query
                                   join rsn in _context.RestaurantSerialNumbers on rt.SerialNoId equals rsn.Id
                                   join u in _context.Users on rt.CreatedBy equals u.Id
                                   join c in _context.Cities on rt.CityId equals c.Id
                                   select new UsersTaskDto()
                                   {
                                       
                                       SerialNo = rsn.SerialNumber.ToString(),
                                       FormId = rt.FormId,
                                       CityName = c.CityName,
                                       CreatedBy = u.FirstName + " " + u.LastName,
                                       CreatedOn = rt.CreatedOn
                                   }).ToListAsync();
            if(userTasks.Count < 1)
            {
                throw new ApiExceptions("There are no User Tasks");
            }

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(5))  
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(10)); 

            _memoryCache.Set(cacheKey, userTasks, cacheEntryOptions);
            return userTasks;
        }
    }
}
