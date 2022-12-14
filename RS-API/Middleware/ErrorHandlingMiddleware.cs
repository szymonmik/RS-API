using RS_API.Exceptions;

namespace RS_API.Middleware;

public class ErrorHandlingMiddleware : IMiddleware
{
	public async Task InvokeAsync(HttpContext context, RequestDelegate next)
	{
		try
		{
			await next.Invoke(context);
		}
		catch (BadRequestException badRequestException)
		{
			context.Response.StatusCode = StatusCodes.Status400BadRequest;
			await context.Response.WriteAsync(badRequestException.Message);
		}
		catch (NotFoundException notFoundException)
		{
			context.Response.StatusCode = StatusCodes.Status404NotFound;
			await context.Response.WriteAsync(notFoundException.Message);
		}
		catch (Exception e)
		{
			context.Response.StatusCode = StatusCodes.Status500InternalServerError;
			await context.Response.WriteAsync(e.Message);
		}
	}
}