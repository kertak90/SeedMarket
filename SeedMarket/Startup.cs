using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeedMarketData.Repository;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using SeedMarket.Services;
using SeedMarket.Middleware;

namespace SeedMarket
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddOptions();
            services.AddDbContext<RecordsContext>(options =>
                {
                    var connectionString = _configuration.GetConnectionString("DefaultConnection");
                    System.Console.WriteLine($"connectionStringInStartup: {connectionString}");
                    options.UseNpgsql(connectionString,
                        DbContextOptions => DbContextOptions.MigrationsAssembly(nameof(SeedMarket)));
                });
            services.AddSwaggerGen(c =>
                {
                    c.EnableAnnotations();
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Api",
                        Description = "SeedMarketApi",
                        Version = "v1"
                    });
                });
            services.AddMvc(options => options.EnableEndpointRouting = false);

            //API Services
            services.AddScoped<MainControllerService>();
            services.AddScoped<AlgorithmsTasksSolvingService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {        
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api/swagger/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api/swagger/v1/swagger.json", "Sample API");
                c.RoutePrefix = "api/swagger";
            });
            app.UseMvc();
        }        
    }
}
