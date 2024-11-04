

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ToDoProject.Model.Categories.Entity;
using ToDoProject.Model.ToDos.Entity;
using ToDoProject.Model.Users.Entity;

namespace ToDoProject.Repository.Contexts;

public class BaseDbContext(DbContextOptions<BaseDbContext> options) : IdentityDbContext<User,IdentityRole,string>(options)
{
    public DbSet<ToDo> ToDos { get; set; } = default!;
    public DbSet<Category> Categories { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
