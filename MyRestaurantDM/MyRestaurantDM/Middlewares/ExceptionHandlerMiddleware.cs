using System.Net;

namespace MyRestaurantDM.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> handler;
        private readonly RequestDelegate next;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> handler , RequestDelegate next)
        {
            this.handler = handler;
            this.next = next;
        }

        public async Task InvokeExceptionHandlerAsync(HttpContext context)
        {
            try
            {
                await next(context);

            }
            catch (Exception ex) 
            {
                var errorId = Guid.NewGuid();

                // To log this exception

                handler.LogError(ex, $"{errorId} : {ex.Message}");

                //To return a custom error response message
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "appplication/json";

                var Error = new
                {
                    Id = errorId,
                    Message = "Something went wrong and i will resolve it as soon as possible"
                };

                await context.Response.WriteAsJsonAsync( Error );   
            }
        }
    }
}
