

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ToDoProject.Repository.Contexts;
using ToDoProject.Repository.ToDos.Abstracts;
using ToDoProject.Repository.ToDos.Concretes;
using ToDoProject.Service.ToDoS.Abstracts;
using ToDoProject.Service.ToDoS.Concretes;

namespace ToDoProject.Service.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IToDoService, ToDoService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
