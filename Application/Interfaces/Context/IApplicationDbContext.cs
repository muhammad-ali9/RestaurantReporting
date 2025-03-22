using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Application.Interfaces.Context
{
   public interface IApplicationDbContext
    {
        DbSet<Users> Users { get; set; }
        DbSet<UserRoles> UserRoles { get; set; }
        DbSet<Roles> Roles { get; set; }
        DbSet<Restaurant> Restaurants { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<RestaurantSerialNumber> RestaurantSerialNumbers { get; set; }

        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync();
    }
}
