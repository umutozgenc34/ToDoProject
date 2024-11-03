
using Core.Repository.Concretes;
using Microsoft.EntityFrameworkCore;
using ToDoProject.Model.Categories.Entity;
using ToDoProject.Repository.Categories.Abstracts;
using ToDoProject.Repository.Contexts;

namespace ToDoProject.Repository.Categories.Concretes;

public class CategoryRepository(BaseDbContext context) : EfGenericRepository<BaseDbContext, Category, int>(context), ICategoryRepository
{
    public IQueryable<Category?> GetCategoryWithTodos() => Context.Categories.Include(x => x.ToDos).AsQueryable();


    public Task<Category?> GetCategoryWithTodosAsync(int id) => Context.Categories.Include(x => x.ToDos).FirstOrDefaultAsync(x => x.Id == id);

}
