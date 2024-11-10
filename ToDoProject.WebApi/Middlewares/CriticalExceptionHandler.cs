using Core.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using SendGrid.Helpers.Mail;
using SendGrid;
using System.Net;
using System.Security.Claims;

namespace ToDoProject.WebApi.Middlewares;

public class CriticalExceptionHandler : IExceptionHandler
{
    private readonly string sendGridApiKey = "SG.3fgh5u4s5hJ9jf5d8w8Jad3K9eU9Z7zV4e8jlfyAhDQ"; 
    private readonly string senderEmail = "umutozgenc34@gmail.com"; 

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception.GetType() == typeof(CriticalException))
        {
            
            var recipientEmail = httpContext.User.Claims.FirstOrDefault(x => x.Type == "email")?.Value;

            
            if (recipientEmail == null)
            {
                Console.WriteLine("E-posta adresi bulunamadı.");
                return true;
            }

            Console.WriteLine("Hata ile ilgili mail gönderildi");
            await SendEmailAsync(recipientEmail, exception.Message);
            return true; 
        }

        return await ValueTask.FromResult(false);
    }

    private async Task SendEmailAsync(string recipientEmail, string message)
    {
        var client = new SendGridClient(sendGridApiKey);
        var from = new EmailAddress(senderEmail, "Sender Name");
        var to = new EmailAddress(recipientEmail, "Recipient Name");
        var subject = "Critical Exception Occurred";
        var plainTextContent = message;
        var htmlContent = $"<strong>{message}</strong>";
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

        
        var response = await client.SendEmailAsync(msg);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            
            Console.WriteLine($"E-posta gönderiminde hata: {response.StatusCode}");
        }
    }
}
