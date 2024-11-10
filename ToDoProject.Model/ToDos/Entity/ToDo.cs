
using Core.Entities;
using ToDoProject.Model.Categories.Entity;
using ToDoProject.Model.ToDos.Enum;
using ToDoProject.Model.Users.Entity;

namespace ToDoProject.Model.ToDos.Entity;

public sealed class ToDo : BaseEntity<Guid>, IAuditEntity
{

    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public Priority Priority { get; set; }
    public bool Completed { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public string? UserId { get; set; }
    public User User { get; set; }
}
