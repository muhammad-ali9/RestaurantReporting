using Domain;

namespace Application.Interfaces
{
    public interface IRestaurantTasks
    {
        Task<int> CreateRestaurantTaskAsync(RestaurantTasks restaurantTask);
    }
}
