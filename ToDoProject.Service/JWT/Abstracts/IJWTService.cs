
using ToDoProject.Model.Tokens.Dtos.Response;
using ToDoProject.Model.Users.Entity;

namespace ToDoProject.Service.JWT.Abstracts;

public interface IJwtService
{
    Task<TokenResponseDto> CreateToken(User user);
}
