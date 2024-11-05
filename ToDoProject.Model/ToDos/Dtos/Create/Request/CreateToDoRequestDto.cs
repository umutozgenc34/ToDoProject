using ToDoProject.Model.ToDos.Enum;

namespace ToDoProject.Model.ToDos.Dtos.Create.Request;

public record CreateToDoRequestDto(
    string Title,
    string Description,
    Priority Priority,
    int CategoryId,
    DateTime StartDate,
    DateTime EndDate,
    bool Completed
    
);
