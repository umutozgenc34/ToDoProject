
using ToDoProject.Model.Tokens.Dtos.Response;
using ToDoProject.Model.Users.Dtos.Request;

namespace ToDoProject.Service.Authentication.Abstracts;

public interface IAuthenticationService
{

    Task<TokenResponseDto> RegisterByTokenAsync(RegisterRequestDto dto);
    Task<TokenResponseDto> LoginByTokenAsync(LoginRequestDto dto);
}
