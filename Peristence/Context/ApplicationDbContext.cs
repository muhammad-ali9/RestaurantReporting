using Application.Interfaces.Context;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Peristence.Context
{
    class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<RestaurantSerialNumber> RestaurantSerialNumbers { get; set; }

        public DbSet<RestaurantTasks> RestaurantTasks { get; set; }
        public DatabaseFacade Database => base.Database;

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure RestaurantSerialNumber relationship
            modelBuilder.Entity<RestaurantTasks>()
                .HasOne(rt => rt.RestaurantSerialNumber)
                .WithMany(rsn => rsn.RestaurantTasks)
                .HasForeignKey(rt => rt.SerialNoId)
                .OnDelete(DeleteBehavior.NoAction); // Prevents cascade issues

            // Configure other relationships similarly
            modelBuilder.Entity<RestaurantTasks>()
                .HasOne(rt => rt.City)
                .WithMany()
                .HasForeignKey(rt => rt.CityId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RestaurantTasks>()
                .HasOne(rt => rt.CreatedByUser)
                .WithMany()
                .HasForeignKey(rt => rt.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RestaurantTasks>()
                .HasOne(rt => rt.ModifiedByUser)
                .WithMany()
                .HasForeignKey(rt => rt.ModifiedBy)
                .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRoles>()
           .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRoles>()
               .HasOne(ur => ur.User)
               .WithMany(u => u.UserRoles)
               .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRoles>()
              .HasOne(ur => ur.Role)
              .WithMany(r => r.UserRoles)
              .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<Roles>().HasData(
                new Roles
                {
                    Id = 1,
                    RoleName = "SuperAdmin"
                }
                );
            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    Id = 1,
                    FirstName = "Muhammad",
                    LastName = "Ali",
                    Password = BCrypt.Net.BCrypt.HashPassword("SuperAdmin@123"),
                    Email = "superadmin@gmail.com"
                }
                );

            modelBuilder.Entity<UserRoles>().HasData(new UserRoles
            {
                UserId = 1,
                RoleId = 1
            });

            modelBuilder.Entity<RestaurantTasks>()
                .HasOne(rt => rt.CreatedByUser)
                .WithMany(u => u.CreatedTasks)
                .HasForeignKey(rt => rt.CreatedBy)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RestaurantTasks>()
                .HasOne(rt => rt.ModifiedByUser)
                .WithMany(u => u.ModifiedTasks)
                .HasForeignKey(rt => rt.ModifiedBy);

            modelBuilder.Entity<RestaurantSerialNumber>()
                .HasOne(rs => rs.City)
                .WithMany(c => c.SerialNumbers)
                .HasForeignKey(rs => rs.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RestaurantTasks>()
                .HasOne(rt => rt.City)
                .WithMany(c => c.RestaurantTasks)
                .HasForeignKey(rt => rt.CityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
