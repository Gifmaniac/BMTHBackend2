namespace BMTH_Application__back_end_.Middleware
{
    public class ApiMiddleWare
    {
        // Lets the request move if allowed
        private readonly RequestDelegate _next;

        private readonly IConfiguration _config;
        private const string ApiAuthorazition = "ApiKey";

        public ApiMiddleWare(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/swagger"))
            {
                await _next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue(ApiAuthorazition, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;      // Unauthorized
                await context.Response.WriteAsync("API Key is missing");
                return;
            }

            var apiKey = _config["ApiKey"];
            if (apiKey == null || !apiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 403;      //Forbidden
                return;
            }

            await _next(context);
        }
    }
}
