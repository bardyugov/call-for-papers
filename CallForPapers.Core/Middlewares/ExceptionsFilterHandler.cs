namespace CallForPapers.Core.Middlewares;

using System.Net;
using System.Text.Json;
using FluentValidation;

public class ExceptionsFilterHandler
{
    private readonly RequestDelegate _next;

    public ExceptionsFilterHandler(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleException(exception, context);
        }
    }

    private Task HandleException(Exception exception, HttpContext context)
    {
        var code = HttpStatusCode.BadRequest;
        var result = string.Empty;

        switch (exception)
        {
            case ValidationException validationException:
                code = HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(validationException.Errors);
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
            
        if (result == null || result == "")
        {
            result = JsonSerializer.Serialize(new { Error = exception.Message });
        }

        return context.Response.WriteAsync(result);
    }
}