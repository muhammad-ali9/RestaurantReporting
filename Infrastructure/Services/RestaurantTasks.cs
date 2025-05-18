using System.Security.Cryptography;
using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Context;
using Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;

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

        public async Task<List<UsersTaskDto>> GetUserTasksAsync()
        {
            var userTasks = await (from rt in _context.RestaurantTasks
                                   join rsn in _context.RestaurantSerialNumbers on rt.SerialNoId equals rsn.Id
                                   join u in _context.Users on rt.CreatedBy equals u.Id
                                   join c in _context.Cities on rt.CityId equals c.Id
                                   where rt.CreatedBy == (int)Convert.ToInt64(_loggedInUser.UserId)
                                   select new UsersTaskDto()
                                   {
                                       
                                       SerialNo = rsn.SerialNumber.ToString(),
                                       FormId = rt.FormId,
                                       CityName = c.CityName,
                                       CreatedBy = u.FirstName + " " + u.LastName,
                                       CreatedOn = rt.CreatedOn
                                   }).ToListAsync();

            return userTasks;
        }
    }
}
