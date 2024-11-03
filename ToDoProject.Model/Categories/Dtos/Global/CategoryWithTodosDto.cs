

using ToDoProject.Model.ToDos.Dtos.Global;

namespace ToDoProject.Model.Categories.Dtos.Global;

public record CategoryWithTodosDto(int Id, string Name , List<ToDoDto> ToDos);

