using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IRestaurantService
    {
        Task<int> CreateRestaurantAsync(CreateRestaurantDto createRestaurant);
        Task<int> DeleteRestauratnAsync(int id);
    }
}
