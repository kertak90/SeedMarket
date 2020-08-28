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
        private IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //API Services
            services.AddScoped<MainControllerService>();
            services.AddScoped<AlgorithmsTasksSolvingService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // app.UseSwagger(c =>
            // {
            //     c.RouteTemplate = "api/swagger/{documentName}/swagger.json";
            // });
            // app.UseSwaggerUI(c =>
            // {
            //     c.SwaggerEndpoint("/api/swagger/v1/swagger.json", "Sample API");
            //     c.RoutePrefix = "api/swagger";
            // });
            // app.UseAuthentication();
            // app.UseMvc();

            #region example2
            // int x = 2;
            // app.UseRouting();
            // app.UseEndpoints(eb =>
            //     {
            //         eb.MapGet("/Hello", async context =>
            //         {
            //             await context.Response.WriteAsync("Hello Oleg");
            //         });
            //         eb.MapGet("/Env", async context =>
            //         {
            //             await context.Response.WriteAsync($"{_env.EnvironmentName}");
            //         });
            //         eb.MapGet("/MultNumber", async context =>
            //         {
            //             x = x * 2;
            //             await context.Response.WriteAsync($"{x}");
            //         });

            //     });

            // int a = 5;
            // int b = 8;
            // int c = 0;
            // app.Use(async (context, next) =>
            // {
            //     c = a * b;
            //     await next.Invoke();
            // });
            // //Данный метод не передает обработку запроса далее по конвейеру
            // // поэтому его лучше размещать в конце.
            // app.Run(async context => 
            // {
            //     System.Console.WriteLine($"Run started");
            //     await context.Response.WriteAsync($"c = {c}");
            // });
            #endregion example2

            #region example3
            // app.Map("/Index", Index);
            // app.Map("/About", About);

            // app.Run(async context =>
            // {
            //     await context.Response.WriteAsync("No such page");
            // });
            #endregion example3

            #region example3.2
            // app.Map("/Home", home =>
            // {
            //     home.Map("/Index", Index);
            //     home.Map("/About", About);
            // });

            // app.Run(async context =>
            // {
            //     await context.Response.WriteAsync("No such page");
            // });
            #endregion example3.2

            #region example4
            // app.MapWhen(context =>
            // {
            //     return context.Request.Query.ContainsKey("id") && context.Request.Query["id"] == "5";
            // }, HandleId);
            // app.Run(async context =>
            // {
            //     await context.Response.WriteAsync("id is not equal 5");
            // });
            #endregion example4

            #region example5
            // app.UseMiddleware<TokenMiddleware>();
            // app.Run(async context =>
            // {
            //     await context.Response.WriteAsync("HelloWorld");
            // });
            #endregion example5

            #region example6
            // app.UseToken("55555");
            // app.Run(async context =>
            // {
            //     await context.Response.WriteAsync("Hello world");
            // });
            #endregion example6

            #region example7
            app.UseMiddleware<TokenMiddleware>("55555");
            app.UseMiddleware<RoutingMiddleware>();
            #endregion example7
        }
        #region example3.1
        private static void Index(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Index page");
            });
        }
        private static void About(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("About");
            });
        }
        #endregion example3.1

        #region example4.1
        private static void HandleId(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("id is equal 5");
            });
        }
        #endregion example4.1
    }
}
