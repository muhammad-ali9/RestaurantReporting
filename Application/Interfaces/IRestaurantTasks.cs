using Application.DTOs;

namespace Application.Interfaces
{
    public interface IRestaurantTasks
    {
        Task<int> CreateRestaurantTaskAsync(RestaurantTasksDto restaurantTask);
        Task<List<UsersTaskDto>> GetUserTasksAsync();
    }
}
