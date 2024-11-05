

using ToDoProject.Model.ToDos.Enum;

namespace ToDoProject.Model.ToDos.Dtos.Global;

public record ToDoDto(
    Guid Id,
    string Title,
    string Description,
    DateTime StartDate,
    DateTime EndDate,
    Priority Priority,
    bool Completed,
    string CategoryName,
    string UserUserName
);
