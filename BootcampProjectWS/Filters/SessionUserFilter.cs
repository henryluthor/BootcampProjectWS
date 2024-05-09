using Microsoft.AspNetCore.Mvc.Filters;

namespace BootcampProjectWS.Filters
{
    public class SessionUserFilter: IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine("Hola");
            await next();
            Console.WriteLine("Adios");
        }
    }
}
