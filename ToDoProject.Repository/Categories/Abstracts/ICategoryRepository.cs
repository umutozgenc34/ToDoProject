

using Core.Repository.Abstracts;
using ToDoProject.Model.Categories.Entity;

namespace ToDoProject.Repository.Categories.Abstracts;

public interface ICategoryRepository : IGenericRepository<Category,int>
{
    Task<Category?> GetCategoryWithTodosAsync(int id);
    IQueryable<Category?> GetCategoryWithTodos();
}
