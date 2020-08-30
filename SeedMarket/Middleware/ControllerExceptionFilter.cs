using Microsoft.AspNetCore.Mvc.Filters;

namespace SeedMarket.Middleware
{
    public class ControllerExceptionFilter : ExceptionFilterAttribute
    {
        public ControllerExceptionFilter(){}
        public override void OnException(ExceptionContext context)
        {
            System.Console.WriteLine($"message:\n{context.Exception.Message}");
        }
    }
}