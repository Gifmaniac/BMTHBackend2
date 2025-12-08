namespace BMTH_Application_back_end_.Middleware;

public class ApiMiddleWare
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _config;
    private const string ApiAuthorization = "ApiKey";

    public ApiMiddleWare(RequestDelegate next, IConfiguration config)
    {
        _next = next;
        _config = config;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        if (HttpMethods.IsOptions(context.Request.Method))
        {
            await _next(context).ConfigureAwait(false);
            return;
        }

        if (context.Request.Path.StartsWithSegments("/swagger", StringComparison.OrdinalIgnoreCase))
        {
            await _next(context).ConfigureAwait(false);
            return;
        }

        if (!context.Request.Headers.TryGetValue(ApiAuthorization, out var extractedApiKey))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Missing API key").ConfigureAwait(false);
            return;
        }

        var validKey = _config.GetValue<string>("ApiKey");
        if (extractedApiKey != validKey)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Invalid API key").ConfigureAwait(false);
            return;
        }

        await _next(context).ConfigureAwait(false);
    }

}
