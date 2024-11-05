

using Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using ToDoProject.Model.Users.Entity;

namespace ToDoProject.Service.Users.Rules;

public class UserBusinessRules
{
    public void CheckUserExists(User? user)
    {
        if (user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı.");
        }
    }

    public void PasswordChangeSucceeded(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            throw new BusinessException("Şifre değişikliği başarısız");
        }
    }

    public void PasswordIsValid(bool passwordCheck)
    {
        if (!passwordCheck)
        {
            throw new CriticalException("Hatalı şifre.");
        }
    }

    public void UpdateIsSuccessful(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            throw new BusinessException("Kullanıcı güncelleme işlemi başarısız.");
        }
    }


}
