using System.Net;
using System.Text.Json;
using Application.Exceptions;
using Application.Response;

namespace WebApi.ErrorHandlingMiddleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new ApiResponse<string> { Message = ex.Message };

                switch(ex)
                {
                    case ApiExceptions e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}
