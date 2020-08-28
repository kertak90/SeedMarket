using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SeedMarket.Middleware
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        private string _pattern;
        public TokenMiddleware(RequestDelegate next, string pattern)
        {
            _next = next;
            _pattern = pattern;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if(token != _pattern)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Token is invalid");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}