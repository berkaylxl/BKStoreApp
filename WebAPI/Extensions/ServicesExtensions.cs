﻿using Microsoft.EntityFrameworkCore;
using Repositories.EfCore;

namespace WebAPI.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) =>
             services.AddDbContext<RepositoryContext>(options =>
                  options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        
    }
}
