

using ToDoProject.Model.ToDos.Enum;

namespace ToDoProject.Model.ToDos.Dtos.Create.Response;

public record CreateToDoResponseDto(
    Guid Id,
    string Title,
    string Description,
    Priority Priority,
    bool Completed,
    string CategoryName
    
);
