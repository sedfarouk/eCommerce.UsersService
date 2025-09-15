namespace eCommerce.API.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception e)
        {
            // Log the exception type and message
            logger.LogError($"{e.GetType().ToString()}: {e.Message}");

            if (e.InnerException is not null)
            {
                // Log the inner exception type and message
                logger.LogError($"{e.InnerException.GetType().ToString()}: {e.InnerException.Message}"); 
            }
            
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(new {Message = e.Message, Type = e.GetType().ToString()});
            throw;
        }
    }
}

// Extension method used to add the middleware to the HTTP request pipeline 
public static class ExceptionHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}