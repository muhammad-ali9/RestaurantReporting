using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Context;
using Domain;
using Microsoft.EntityFrameworkCore;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
        }
    }
}
