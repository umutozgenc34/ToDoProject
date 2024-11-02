using Core.Entities;
using ToDoProject.Model.ToDos.Entity;

namespace ToDoProject.Model.Categories.Entity;

public sealed class Category : BaseEntity<int>
{
    public string Name { get; set; } = default!;
    public List<ToDo> ToDos { get; set; } 

}
