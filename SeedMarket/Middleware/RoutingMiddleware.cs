using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SeedMarket.Middleware
{
    public class RoutingMiddleware
    {
        private readonly RequestDelegate _next;
        public RoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path.Value.ToLower();
            if(path == "/index")
            {
                await context.Response.WriteAsync("Index page");
            }
            else if(path == "/market")
            {
                await context.Response.WriteAsync("Market page");
            }
            else
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("no such page");
            }
        }
    }
}