using Core.Entities.ReturnModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoProject.Model.Tokens.Dtos.Response;
using ToDoProject.Model.Users.Dtos.Request;
using ToDoProject.Service.Authentication.Abstracts;

namespace ToDoProject.WebApi.Controllers;
public class AuthenticationsController(IAuthenticationServicee authService) : CustomBaseController
{
    [HttpPost("register")]
    public async Task<IActionResult> CreateUser([FromBody] RegisterRequestDto request)
    {
        var tokenResponse = await authService.RegisterByTokenAsync(request);
        var response = ReturnModel<TokenResponseDto>.Success(tokenResponse);
        return CreateActionResult(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
    {
        var tokenResponse = await authService.LoginByTokenAsync(request);
        var response = ReturnModel<TokenResponseDto>.Success(tokenResponse);
        return CreateActionResult(response);
    }
}
