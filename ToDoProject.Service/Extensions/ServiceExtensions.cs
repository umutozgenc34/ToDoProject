

using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ToDoProject.Repository.Contexts;
using ToDoProject.Repository.ToDos.Abstracts;
using ToDoProject.Repository.ToDos.Concretes;
using ToDoProject.Service.Categories.Abstracts;
using ToDoProject.Service.Categories.Concretes;
using ToDoProject.Service.ToDoS.Abstracts;
using ToDoProject.Service.ToDoS.Concretes;
using ToDoProject.Service.Users.Abstracts;
using ToDoProject.Service.Users.Concretes;

namespace ToDoProject.Service.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICategoryService,CategoryService>();
        services.AddScoped<IToDoService, ToDoService>();
        services.AddScoped<IUserService, UserService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
