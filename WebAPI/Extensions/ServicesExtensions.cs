﻿using Microsoft.EntityFrameworkCore;
using Repositories.Contract;
using Repositories.EfCore;
using Services;
using Services.Contracts;

namespace WebAPI.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) =>
             services.AddDbContext<RepositoryContext>(options =>
                  options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        
        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }

        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
        }
    }
}
