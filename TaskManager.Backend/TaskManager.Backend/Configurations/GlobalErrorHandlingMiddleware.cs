using System.Net;
using System.Text.Json;
using TaskManager.Backend.Exceptions;

namespace TaskManager.Backend.Configurations
{
	public class GlobalErrorHandlingMiddleware
	{
		private readonly RequestDelegate _next;

		public GlobalErrorHandlingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionsAsync(context, ex);
			}
		}

		public static Task HandleExceptionsAsync(HttpContext context, Exception ex)
		{
			HttpStatusCode status;
			string message = string.Empty;
			string? stackTrace = string.Empty;

			Type exceptionType = ex.GetType();

			switch (exceptionType.Name)
			{
				case nameof(BadRequestException):
					status = HttpStatusCode.BadRequest;
					message = ex.Message;
					stackTrace = ex.StackTrace;
					break;

				case nameof(UnauthorizedException):
					status = HttpStatusCode.Unauthorized;
					message = ex.Message;
					stackTrace = ex.StackTrace;
					break;

				case nameof(ForbiddenException):
					status = HttpStatusCode.Forbidden;
					message = ex.Message;
					stackTrace = ex.StackTrace;
					break;

				case nameof(NotFoundException):
					status = HttpStatusCode.NotFound;
					message = ex.Message;
					stackTrace = ex.StackTrace;
					break;

				default:
					status = HttpStatusCode.InternalServerError;
					message = "Error interno del servidor";
					stackTrace = ex.StackTrace;
					break;
			}

			Console.WriteLine(stackTrace);

			var exceptionResponse = JsonSerializer.Serialize(new { status, error = message });
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)status;

			return context.Response.WriteAsync(exceptionResponse);
		}
	}
}
