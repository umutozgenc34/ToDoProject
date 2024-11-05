

using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ToDoProject.Repository.Contexts;
using ToDoProject.Repository.ToDos.Abstracts;
using ToDoProject.Repository.ToDos.Concretes;
using ToDoProject.Service.Authentication.Abstracts;
using ToDoProject.Service.Authentication.Concretes;
using ToDoProject.Service.Authentication.Rules;
using ToDoProject.Service.Categories.Abstracts;
using ToDoProject.Service.Categories.Concretes;
using ToDoProject.Service.Categories.Rules;
using ToDoProject.Service.JWT.Abstracts;
using ToDoProject.Service.JWT.Concretes;
using ToDoProject.Service.ToDoS.Abstracts;
using ToDoProject.Service.ToDoS.Concretes;
using ToDoProject.Service.ToDoS.Rules;
using ToDoProject.Service.Users.Abstracts;
using ToDoProject.Service.Users.Concretes;
using ToDoProject.Service.Users.Rules;

namespace ToDoProject.Service.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICategoryService,CategoryService>();
        services.AddScoped<IToDoService, ToDoService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IJwtService,JwtService>();
        services.AddScoped<IAuthenticationServicee, AuthenticationServicee>();
        services.AddScoped<ToDoBusinessRules>();
        services.AddScoped<CategoryBusinessRules>();
        services.AddScoped<AuthenticationBusinessRules>();
        services.AddScoped<UserBusinessRules>();
        
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
