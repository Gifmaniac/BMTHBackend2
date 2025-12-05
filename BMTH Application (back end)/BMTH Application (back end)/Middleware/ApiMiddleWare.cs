namespace BMTH_Application_back_end_.Middleware;

public class ApiMiddleWare
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _config;
    private const string ApiAuthorazition = "ApiKey";

    public ApiMiddleWare(RequestDelegate next, IConfiguration config)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _config = config ?? throw new ArgumentNullException(nameof(config));
    }

    public async Task InvokeAsync(HttpContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        if (!context.Request.Headers.TryGetValue(ApiAuthorazition, out var extractedApiKey))
        {
            return;
        }

        // Allow OPTIONS calls
        if (HttpMethods.IsOptions(context.Request.Method))
        {
            await _next(context).ConfigureAwait(false);
            return;
        }

        // Skip API key check for swagger
        if (context.Request.Path.StartsWithSegments("/swagger", StringComparison.OrdinalIgnoreCase))
        {
            await _next(context).ConfigureAwait(false);
            return;
        }
    }
}
