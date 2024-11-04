using Core.Entities.ReturnModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ToDoProject.Model.Tokens.Dtos.Response;
using ToDoProject.Model.Users.Dtos.Request;
using ToDoProject.Service.Authentication.Abstracts;
using ToDoProject.Service.JWT.Abstracts;
using ToDoProject.Service.Users.Abstracts;

namespace ToDoProject.Service.Authentication.Concretes;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserService _userService;
    private readonly IJwtService _jwtService;

    public AuthenticationService(IUserService userService, IJwtService jwtService)
    {
        _userService = userService;
        _jwtService = jwtService;
    }

    public async Task<TokenResponseDto> LoginByTokenAsync(LoginRequestDto dto)
    {
        var loginResponse = await _userService.LoginAsync(dto);
        if (loginResponse.Data is null)
        {
            throw new Exception("");
        }
        var tokenResponse = await _jwtService.CreateToken(loginResponse.Data);
        return tokenResponse;
    }

    public async Task<TokenResponseDto> RegisterByTokenAsync(RegisterRequestDto dto)
    {
        var registerResponse = await _userService.CreateUserAsync(dto);
        if (registerResponse.Data is null)
        {
            throw new Exception("");
        }
        var tokenResponse = await _jwtService.CreateToken(registerResponse.Data);
        return tokenResponse;
    }
}
