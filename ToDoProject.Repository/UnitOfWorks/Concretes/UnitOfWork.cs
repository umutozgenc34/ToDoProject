

using ToDoProject.Repository.Contexts;
using ToDoProject.Repository.UnitOfWorks.Abstracts;

namespace ToDoProject.Repository.UnitOfWorks.Concretes;

public class UnitOfWork(BaseDbContext context) : IUnitOfWork
{
    public Task<int> SaveChangesAsync() => context.SaveChangesAsync();
    
}
