using Core.Entities.ReturnModels;
using Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ToDoProject.Model.Tokens.Dtos.Response;
using ToDoProject.Model.Users.Dtos.Request;
using ToDoProject.Service.Authentication.Abstracts;
using ToDoProject.Service.Authentication.Rules;
using ToDoProject.Service.JWT.Abstracts;
using ToDoProject.Service.Users.Abstracts;

namespace ToDoProject.Service.Authentication.Concretes;

public class AuthenticationServicee(IUserService userService, IJwtService jwtService, AuthenticationBusinessRules businessRules) : IAuthenticationServicee
{
    //private readonly IUserService _userService = userService;
    //private readonly IJwtService _jwtService = jwtService;
    //private readonly AuthenticationBusinessRules _businessRules = businessRules;

    public async Task<TokenResponseDto> LoginByTokenAsync(LoginRequestDto dto)
    {
        businessRules.ValidateLoginRequest(dto);

        var loginResponse = await userService.LoginAsync(dto);
        if (loginResponse.Data is null)
        {
            throw new NotFoundException("Giriş işlemi başarısız");
        }
        var tokenResponse = await jwtService.CreateToken(loginResponse.Data);
        return tokenResponse;
    }

    public async Task<TokenResponseDto> RegisterByTokenAsync(RegisterRequestDto dto)
    {
        businessRules.ValidateRegisterRequest(dto);
        var registerResponse = await userService.CreateUserAsync(dto);
        if (registerResponse.Data is null)
        {
            throw new NotFoundException("Kayıt işlemi başarısız");
        }
        var tokenResponse = await jwtService.CreateToken(registerResponse.Data);
        return tokenResponse;
    }
}
