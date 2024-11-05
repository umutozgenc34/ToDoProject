

using Core.Entities.ReturnModels;
using Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using ToDoProject.Model.Users.Dtos.Request;
using ToDoProject.Model.Users.Entity;
using ToDoProject.Service.Constants;
using ToDoProject.Service.Roles.Abstracts;
using ToDoProject.Service.Roles.Rules;

namespace ToDoProject.Service.Roles.Concretes;

public sealed class RoleService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, RoleBusinessRules roleBusinessRules) : IRoleService
{
    public async Task<ReturnModel<string>> AddRoleAsync(string name)
    {
        await roleBusinessRules.CheckIfRoleNameIsUnique(name);

        var role = new IdentityRole { Name = name };
        var result = await roleManager.CreateAsync(role);
        roleBusinessRules.CheckIfRoleCreationSucceeded(result);

        return ReturnModel<string>.Success(Messages.RoleAddedMessage + name);
    }

    public async Task<ReturnModel<string>> AddRoleToUser(RoleAddToUserRequestDto request)
    {
        var role = await roleManager.FindByNameAsync(request.RoleName);
        roleBusinessRules.RoleCheck(role);

        var user = await userManager.FindByIdAsync(request.UserId);
        roleBusinessRules.UserCheck(user);

        var addRoleToUser = await userManager.AddToRoleAsync(user, request.RoleName);
        roleBusinessRules.CheckIfRoleCreationSucceeded(addRoleToUser);

        return ReturnModel<string>.Success(Messages.RoleAddedToUserMessage + request.RoleName);
    }

    public async Task<ReturnModel<List<string>>> GetAllRolesByUserId(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        roleBusinessRules.UserCheck(user);
        var roles = await userManager.GetRolesAsync(user);


        return ReturnModel<List<string>>.Success(roles.ToList());
    }
}
