using Maquisistema.Domain.Repository;
using Maquisistema.Domain.Services;
using Maquisistema.Infrastructure.Data;
using Maquisistema.Infrastructure.Repository;
using Maquisistema.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maquisistema.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection services, IConfiguration configuration)

        {
            services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<MaquisistemaDbContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("MaquisistemaConnectionStringSqlServer") ??
                    throw new InvalidOperationException("Connection string 'MaquisistemaConnectionStringSqlServer' not found"), b => b.MigrationsAssembly("Product.API"));
                }
            );

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductDiscountService, ProductDiscountService>();
            services.AddTransient<IMemoryCache, MemoryCache>();

            services.AddHttpClient("MockApiClient", httpClient =>
            {
                httpClient.BaseAddress = new Uri(configuration.GetSection("Services").GetSection("MockApiServiceURI").Value);
            });

            return services;

        }
    }
}
