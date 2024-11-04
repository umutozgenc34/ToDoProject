﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;


namespace ToDoProject.Repository.Interceptors;

public class AuditDbContextInterceptor : SaveChangesInterceptor
{
    private static readonly Dictionary<EntityState, Action<DbContext, IAuditEntity>> Behaviors = new()
        {
            { EntityState.Added, AddBehavior },
            { EntityState.Modified, ModifiedBehavior }
        };


    private static void AddBehavior(DbContext context, IAuditEntity auditEntity)
    {
        auditEntity.CreatedDate = DateTime.Now;
        context.Entry(auditEntity).Property(x => x.UpdatedDate).IsModified = false;
    }

    private static void ModifiedBehavior(DbContext context, IAuditEntity auditEntity)
    {
        context.Entry(auditEntity).Property(x => x.CreatedDate).IsModified = false;
        auditEntity.UpdatedDate = DateTime.Now;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entityEntry in eventData.Context!.ChangeTracker.Entries().ToList())
        {
            if (entityEntry.Entity is not IAuditEntity auditEntity) continue;


            if (entityEntry.State is not (EntityState.Added or EntityState.Modified)) continue;


            Behaviors[entityEntry.State](eventData.Context, auditEntity);


        }
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
