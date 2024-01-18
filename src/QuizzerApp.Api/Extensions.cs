using Microsoft.AspNetCore.Diagnostics;
using QuizzenApp.Shared.Dto;
using QuizzenApp.Shared.Exceptions;

namespace QuizzerApp.Api;

public static class Extensions
{
    public static void ConfigureExceptionHandling(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(err =>
        {

            err.Run(async context =>
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerPathFeature>();

                if (contextFeature is not null)
                {
                    ErrorResponse response = new();

                    switch (contextFeature.Error)
                    {
                        case AlreadyExistException exception:
                            context.Response.StatusCode = (int)exception.statusCode;
                            response.Error = exception.Message;
                            break;
                        case DbPhotoSaveException exception:
                            context.Response.StatusCode = (int)exception.StatusCode;
                            response.Error = exception.Message;
                            break;
                        case IdentityException exception:
                            context.Response.StatusCode = (int)exception.statusCode;
                            response.Error = exception.Message;
                            response.Details = exception.Errors;
                            break;
                        case NotFoundException exception:
                            context.Response.StatusCode = (int)exception.statusCode;
                            response.Error = exception.Message;
                            break;
                        case PhotoSaveException exception:
                            context.Response.StatusCode = (int)exception.StatusCode;
                            response.Error = exception.Message;
                            break;
                        case WrongSigninCredentialsException exception:
                            context.Response.StatusCode = (int)exception.statusCode;
                            response.Error = exception.Message;
                            break;

                        default:
                            response.Error = contextFeature.Error.Message;
                            response.InnerException = contextFeature.Error.InnerException;
                            break;
                    }



                    await context.Response.WriteAsync(response.ToString());
                }
            });
        });
    }
}
