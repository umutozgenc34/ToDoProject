

namespace ToDoProject.Model.Users.Dtos.Request;

public sealed record ChangePasswordRequestDto(string OldPassword, string NewPassword);
