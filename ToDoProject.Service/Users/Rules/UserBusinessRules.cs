

using Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using ToDoProject.Model.Users.Entity;
using ToDoProject.Service.Constants;

namespace ToDoProject.Service.Users.Rules;

public class UserBusinessRules
{
    public void CheckUserExists(User? user)
    {
        if (user is null)
        {
            throw new NotFoundException(Messages.UserNotFountMessage);
        }
    }

    public void PasswordChangeSucceeded(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            throw new BusinessException(Messages.PasswordChangeUnsuccesfullMessage);
        }
    }

    public void PasswordIsValid(bool passwordCheck)
    {
        if (!passwordCheck)
        {
            throw new CriticalException(Messages.WrongPasswordMessage);
        }
    }

    public void UpdateIsSuccessful(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            throw new BusinessException(Messages.UserUpdateUnsuccesfullMessage);
        }
    }


}
