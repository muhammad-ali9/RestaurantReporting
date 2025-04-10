﻿using Application.DTOs;

namespace Application.Interfaces
{
    public interface IRestaurantService
    {
        Task<int> CreateRestaurantAsync(CreateRestaurantDto createRestaurant);
        Task<int> DeleteRestaurantAsync(int id);
        Task<int> DeleteCityAsync(int id);
        Task<List<RestaurantSerialDto>> GetSerialNumberAsync(int id);
        Task<List<string>> GetAllCitiesAsync();
    }
}
