namespace ToDoProject.Model.Users.Dtos.Request;

public sealed record RegisterRequestDto(string FirstName,
    string Lastname,
    string Username,
    string Email,
    string Password
    );
