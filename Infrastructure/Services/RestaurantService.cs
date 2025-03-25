using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Context;
using Domain;
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
                await _context.Cities.AddAsync(city);
                await _context.SaveChangesAsync();
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

        public async Task<int> DeleteCity(int id)
        {
           var city = await _context.Cities.FirstOrDefaultAsync(c => c.Id == id);
            if (city == null)
            {
                throw new ApiExceptions("City Not Found");
            }
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {

                    await _context
                        .Database
                        .ExecuteSqlRawAsync("Delete From Restaurants Where SerialNumberId In ( Select Id From RestaurantSerialNumbers Where CityId = {0})", id);
                    
                    await _context
                        .Database
                        .ExecuteSqlRawAsync("Delete From RestaurantSerialNumbers Where CityId = {0}", id);

                    _context.Cities.Remove(city);
                    await _context.SaveChangesAsync();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new ApiExceptions(ex.Message);
                }
            }
           // _context.Cities.Remove(city);
           // await _context.SaveChangesAsync();

           //await _context.Database.ExecuteSqlRawAsync("Delete From Restaurants Where SerialNumberId In ( Select Id From RestaurantSerialNumbers Where CityId = {0})", id);
           // await _context.Database.ExecuteSqlRawAsync("Delete From RestaurantSerialNumbers Where CityId = {0}", id);

            return id;
        }

        public async Task<int> DeleteRestaurantAsync(int id)
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
