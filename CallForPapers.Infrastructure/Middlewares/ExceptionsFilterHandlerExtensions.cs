using Microsoft.AspNetCore.Builder;

namespace CallForPapers.Infrastructure.Middlewares;

public static class ExceptionsFilterHandlerExtensions
{
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionsFilterHandler>();
    }
}