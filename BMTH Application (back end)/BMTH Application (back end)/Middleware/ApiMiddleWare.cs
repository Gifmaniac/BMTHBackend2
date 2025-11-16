namespace BMTH_Application__back_end_.Middleware
{
    public class ApiMiddleWare(RequestDelegate next, IConfiguration config)
    {
        private const string ApiAuthorazition = "ApiKey";


        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/swagger"))
            {
                await next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue(ApiAuthorazition, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;      // Unauthorized
                await context.Response.WriteAsync("API Key is missing");
                return;
            }

            var apiKey = config["ApiKey"];
            if (apiKey == null || !apiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 403;      //Forbidden
                return;
            }

            await next(context);
        }
    }
}
