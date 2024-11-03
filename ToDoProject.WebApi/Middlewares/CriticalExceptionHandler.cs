using Core.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace ToDoProject.WebApi.Middlewares;

public class CriticalExceptionHandler : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        // ilerde yapılacak

        if (exception.GetType() == typeof(CriticalException))
        {
            Console.WriteLine("Hata ile ilgili mail gönderildi");
        }
        return ValueTask.FromResult(false);
    }
}
