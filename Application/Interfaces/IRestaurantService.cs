using Application.DTOs;
using Domain;

namespace Application.Interfaces
{
    public interface IRestaurantService
    {
        Task<int> CreateRestaurantAsync(CreateRestaurantDto createRestaurant);
        Task<int> DeleteRestaurantAsync(int id);
        Task<int> DeleteCityAsync(int id);
        Task<List<RestaurantSerialDto>> GetSerialNumberAsync(int id);
    }
}
