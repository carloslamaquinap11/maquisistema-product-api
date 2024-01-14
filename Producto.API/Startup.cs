using AutoMapper;
using LazyCache;
using LazyCache.Providers;
using Maquisistema.Application;
using Maquisistema.Application.Common.Mappings;
using Maquisistema.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Producto.API.Controllers;
//using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Producto.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(x =>
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Product {groupName}",
                    Version = groupName,
                    Description = "Product API",
                    Contact = new OpenApiContact
                    {
                        Name = "Maquisistema Company",
                        Email = string.Empty,
                        Url = new Uri("https://maquisistema.com/"),
                    }
                });
            });

            services.AddApplicationServices();
            services.AddInfrastructureServices(Configuration);


            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile(new DomainToViewModelMappingProfile());
                x.AddProfile(new ViewModelToDomainMappingProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());
            services.AddSingleton<IAppCache>(new CachingService(new MemoryCacheProvider(
                                 new MemoryCache(
                                  new MemoryCacheOptions()))));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API V1");
                });
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
