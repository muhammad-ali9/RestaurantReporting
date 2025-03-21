using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Context;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IApplicationDbContext _context;
        public RestaurantService(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateRestaurantAsync(CreateRestaurantDto createRestaurant)
        {
            var city = await _context.Cities.FirstOrDefaultAsync(c => c.CityName == createRestaurant.CityName);

            if (city == null)
            {
                city = new Domain.City
                {
                    CityName = createRestaurant.CityName
                };
            }

            var serial = new RestaurantSerialNumber
            {
                CityId = city.Id,
                SerialNumber = createRestaurant.SerialNumber
            };

            await _context.RestaurantSerialNumbers.AddAsync(serial);
            await _context.SaveChangesAsync();

            var restaurant = new Restaurant
            {
                RestaurantName = createRestaurant.RestaurantName,
                Address = createRestaurant.Address,
                SerialNumberId = serial.Id
            };

            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();

            return serial.Id;
        }

        public async Task<int> DeleteRestauratnAsync(int id)
        {
            var restaurant = await _context.Restaurants
                .Include(r => r.SerialNumber)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (restaurant != null)
            {
                _context.Restaurants.Remove(restaurant);

                if (restaurant.SerialNumber != null)
                {
                    _context.RestaurantSerialNumbers.Remove(restaurant.SerialNumber);
                }
                await _context.SaveChangesAsync();

            }
            if (restaurant == null)
            {
                throw new ApiExceptions("Restaurant Not Found");
            }
                return 0;
        }
    }
}
