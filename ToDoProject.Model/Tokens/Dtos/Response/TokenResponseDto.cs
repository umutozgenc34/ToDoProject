

namespace ToDoProject.Model.Tokens.Dtos.Response;

public sealed class TokenResponseDto
{
    public string AccessToken { get; set; }
    public DateTime AccessTokenExpiration { get; set; }
}
