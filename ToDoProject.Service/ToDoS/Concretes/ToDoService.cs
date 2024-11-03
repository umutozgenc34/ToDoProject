

using Microsoft.EntityFrameworkCore.ChangeTracking;
using ToDoProject.Repository.ToDos.Abstracts;
using ToDoProject.Service.ToDoS.Abstracts;

namespace ToDoProject.Service.ToDoS.Concretes;

public class ToDoService(IToDoRepository toDoRepository) : IToDoService
{
  
}
