
namespace KandaIdea_Task.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;
        public RequestLoggingMiddleware(RequestDelegate next,
            ILogger<RequestLoggingMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            var controllerName = httpContext.GetRouteData()?.Values["controller"]?.ToString();
            var actionName = httpContext.GetRouteData()?.Values["action"]?.ToString();
            var method = httpContext.Request.Method;
            var requestPath = httpContext.Request.Path;
            _logger.LogInformation("Request started: {Method} {RequestPath} Controller: {Controller} Action: {Action}",
                    method, requestPath, controllerName, actionName);

            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while processing the request: {Method} {RequestPath} Controller: {Controller} Action: {Action}",
                    method, requestPath, controllerName, actionName);
                throw;
            }
            var statusCode = httpContext.Response.StatusCode;
            _logger.LogInformation("Request completed: {Method} {RequestPath} StatusCode: {StatusCode} Controller: {Controller} Action: {Action}",
                method, requestPath, statusCode, controllerName, actionName);
        }
    }
}
