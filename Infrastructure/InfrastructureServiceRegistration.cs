﻿using Application.Interfaces;
using Application.Interfaces.Authentication;
using Infrastructure.Services;
using Infrastructure.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthService, AuthService>();
            services.AddScoped<IRestaurantService, RestaurantService>();

            return services;
        }
    }
}
