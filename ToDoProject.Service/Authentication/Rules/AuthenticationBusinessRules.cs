

using Core.Exceptions;
using ToDoProject.Model.Users.Dtos.Request;
using ToDoProject.Model.Users.Entity;

namespace ToDoProject.Service.Authentication.Rules;

public class AuthenticationBusinessRules
{
    public void ValidateLoginRequest(LoginRequestDto request)
    {
        if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
        {
            throw new BusinessException("Email veya şifre boş olamaz.");
        }
    }

    public void ValidateRegisterRequest(RegisterRequestDto request)
    {
        if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
        {
            throw new BusinessException("Email veya şifre boş olamaz.");
        }

    }
}
