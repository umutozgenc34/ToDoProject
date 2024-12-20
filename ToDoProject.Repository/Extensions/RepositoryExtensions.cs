﻿

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using ToDoProject.Repository.Categories.Abstracts;
using ToDoProject.Repository.Categories.Concretes;
using ToDoProject.Repository.Contexts;
using ToDoProject.Repository.Interceptors;
using ToDoProject.Repository.ToDos.Abstracts;
using ToDoProject.Repository.ToDos.Concretes;
using ToDoProject.Repository.UnitOfWorks.Abstracts;
using ToDoProject.Repository.UnitOfWorks.Concretes;


namespace ToDoProject.Repository.Extensions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options =>
        {
            var connectionStrings = configuration.GetSection
            (ConnectionStringOption.Key).Get<ConnectionStringOption>();

            options.UseSqlServer(connectionStrings!.SqlServer, sqlServerOptionsAction =>
            {
                sqlServerOptionsAction.MigrationsAssembly(typeof(RepositoryAssembly).Assembly.FullName);
            });

            options.AddInterceptors(new AuditDbContextInterceptor());

        });

        services.AddScoped<IToDoRepository, ToDoRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        return services;
    }
}
