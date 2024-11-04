using Core.Entities;

using ToDoProject.Model.ToDos.Entity;

namespace ToDoProject.Model.Users.Entity;

public sealed class User : BaseEntity<int>
{
    public List<ToDo> ToDos { get; set; }

}
