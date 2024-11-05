using Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using ToDoProject.Model.Users.Entity;
using ToDoProject.Service.Constants;

namespace ToDoProject.Service.Roles.Rules;

public class RoleBusinessRules(RoleManager<IdentityRole> roleManager)
{
    public void UserCheck(User? user)
    {
        if (user is null)
        {
            throw new NotFoundException(Messages.UserNotFountMessage);
        }
    }

    public void RoleCheck(IdentityRole? role)
    {
        if (role is null)
        {
            throw new BusinessException(Messages.RoleNotFoundMessage);
        }
    }

    public async Task CheckIfRoleNameIsUnique(string name)
    {
        var role = await roleManager.FindByNameAsync(name);
        if (role != null)
            throw new BusinessException(Messages.RoleAlreadyExistsMessage); 
    }

    public void CheckIfRoleCreationSucceeded(IdentityResult result)
    {
        if (!result.Succeeded)
            throw new BusinessException(result.Errors.First().Description);
    }



}
