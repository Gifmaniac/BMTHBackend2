using System;
using System.Threading.Tasks;
using BusinessLayer.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace BMTH_Application_back_end_.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    private static readonly Action<ILogger, string, Exception?> _logValidationError =
        LoggerMessage.Define<string>(
            LogLevel.Error,
            new EventId(2, nameof(ExceptionMiddleware)),
            "Validation error: {Message}");

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task InvokeAsync(HttpContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        try
        {
            await _next(context).ConfigureAwait(false);
        }
        catch (ValidationException ex)
        {
            _logValidationError(_logger, ex.Message, ex);

            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(new { error = ex.Message })
                .ConfigureAwait(false);
        }
        catch (NotFoundException ex)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsJsonAsync(new { error = ex.Message })
                .ConfigureAwait(false);
        }
        catch (TokenGenerationException ex)
        {
            _logValidationError(_logger, ex.Message, ex);

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(new { error = ex.Message }) 
                .ConfigureAwait(false);
            return;
        }
    }
}
