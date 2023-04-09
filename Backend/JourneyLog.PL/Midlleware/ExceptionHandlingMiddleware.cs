using JourneyLog.BLL.Exceptions;
using JourneyLog.BLL.Exceptions.NotFound;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace JourneyLog.PL.Midlleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(
        RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = StatusCodes.Status500InternalServerError;

        switch (exception)
        {
            case NotFoundException:
                code = StatusCodes.Status404NotFound;
                break;
            case AuthException:
                code = StatusCodes.Status401Unauthorized;
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = code;

        return context.Response.WriteAsync(JsonConvert.SerializeObject(new {error = exception.Message}));
    }
}