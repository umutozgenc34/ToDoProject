using Core.Entities;
using Microsoft.AspNetCore.Identity;
using ToDoProject.Model.ToDos.Entity;

namespace ToDoProject.Model.Users.Entity;

public sealed class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<ToDo> ToDos { get; set; }

}
