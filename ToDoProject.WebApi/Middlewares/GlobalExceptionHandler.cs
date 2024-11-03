using Core.Entities.ReturnModels;
using Core.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Linq.Expressions;
using System.Net;
using System.Text.Json;

namespace ToDoProject.WebApi.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception.GetType() == typeof(NotFoundException))
        {
            await WriteResponseAsync(httpContext, ReturnModel.Fail(exception.Message, HttpStatusCode.NotFound), cancellationToken);
            return true;
        }

        if (exception.GetType() == typeof(BusinessException))
        {
            await WriteResponseAsync(httpContext, ReturnModel.Fail(exception.Message, HttpStatusCode.BadRequest), cancellationToken);
            return true;
        }

        
        await WriteResponseAsync(httpContext, ReturnModel.Fail(exception.Message, HttpStatusCode.InternalServerError), cancellationToken);
        return true;
    }

    private static async Task WriteResponseAsync(HttpContext context, ReturnModel response, CancellationToken cancellationToken)
    {
        context.Response.StatusCode = (int)response.Status;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsJsonAsync(response, cancellationToken: cancellationToken);
    }
}


