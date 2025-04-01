using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Context;

namespace Infrastructure.Services
{
    public class RestaurantTasks : IRestaurantTasks
    {
        private readonly IApplicationDbContext _context;
        private readonly ILoggedInUser _loggedInUser;

        public RestaurantTasks(IApplicationDbContext context, ILoggedInUser loggedInUser)
        {
            _context = context;
            _loggedInUser = loggedInUser;
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
    }
}
