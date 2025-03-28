using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Context;

namespace Infrastructure.Services
{
    public class RestaurantTasks : IRestaurantTasks
    {
        private readonly IApplicationDbContext _context;

        public RestaurantTasks(IApplicationDbContext context)
        {
            _context = context;
        }
     

        public async Task<int> CreateRestaurantTaskAsync(RestaurantTasksDto restaurantTask)
        {
            var result = new Domain.RestaurantTasks()
            {
                SerialNoId = restaurantTask.SerialNo,
                FormId = restaurantTask.FormId,
                CityId = restaurantTask.CityId,
                CreatedBy = restaurantTask.CreatedBy

            };
            await _context.RestaurantTasks.AddAsync(result);
            await _context.SaveChangesAsync();
            return result.Id;
        }
    }
}
