

using ToDoProject.Model.ToDos.Enum;

namespace ToDoProject.Model.ToDos.Dtos.Update;

public record UpdateToDoRequestDto(
    
    string Title,
    string Description,
    Priority Priority,
    bool Completed,
    int CategoryId
);
