using Stocklisting.Exception;

namespace Stocklisting.Middleware
{
    public class ExceptionMiddleware : IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            //add the try catch block
            try
            {
                return next(context);
            }

            catch (SharesNotFoundException e)
            {
                context.Response.StatusCode = 404;
                return context.Response.WriteAsync(e.Message);
            }
            catch (SharesAlreadyExistsException e)
            {
                context.Response.StatusCode = 400;
                return context.Response.WriteAsync(e.Message);
            }

        }
    }
}
