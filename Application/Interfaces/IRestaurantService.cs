using Application.DTOs;

namespace Application.Interfaces
{
    public interface IRestaurantService
    {
        Task<int> CreateRestaurantAsync(CreateRestaurantDto createRestaurant);
        Task<int> DeleteRestaurantAsync(int id);
        Task<int> DeleteCity(int id);
    }
}
