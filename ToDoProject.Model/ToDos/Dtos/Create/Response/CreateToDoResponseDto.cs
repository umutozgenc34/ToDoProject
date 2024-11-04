

using ToDoProject.Model.ToDos.Enum;

namespace ToDoProject.Model.ToDos.Dtos.Create.Response;

public record CreateToDoResponseDto(
    Guid Id,
    string Title,
    string Description,
    Priority Priority,
    DateTime StartDate,
    DateTime EndDate,
    bool Completed,
    string CategoryName,
    string UserFirstName
);
