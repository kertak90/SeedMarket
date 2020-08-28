using Microsoft.AspNetCore.Builder;

namespace SeedMarket.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseToken(this IApplicationBuilder builder, string pattern)
        {
            return builder.UseMiddleware<TokenMiddleware>(pattern);
        }
    }
}