using Core.Entities.ReturnModels;
using Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ToDoProject.Model.Users.Dtos.Request;
using ToDoProject.Model.Users.Entity;
using ToDoProject.Service.Users.Abstracts;

namespace ToDoProject.Service.Users.Concretes;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    public UserService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ReturnModel> ChangePasswordAsync(string id, ChangePasswordRequestDto request)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user is null)
        {
            return ReturnModel.Fail("Idye ait user bulunamadı", HttpStatusCode.NotFound);
        }
        var result = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);
        if (result.Succeeded is false)
        {
            return ReturnModel.Fail("Şifre yanlış");
        }
        
        return ReturnModel.Success(HttpStatusCode.OK);
    }

    public async Task <ReturnModel<User>> CreateUserAsync(RegisterRequestDto request)
    {
        User user = new User()
        {
            FirstName = request.FirstName,
            LastName = request.Lastname,
            Email = request.Email,
            UserName = request.Username,
            
        };
        var result = await _userManager.CreateAsync(user, request.Password);
        return ReturnModel<User>.Success(user,HttpStatusCode.Created);
    }

    public async Task<ReturnModel> DeleteAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if(user is null)
        {
            return ReturnModel.Fail("Idye ait kullanıcı bulunamadı");
        }
        await _userManager.DeleteAsync(user);

        return ReturnModel.Success(HttpStatusCode.NoContent);
    }

    public async Task <ReturnModel<User>> GetByEmailAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null)
        {
            return ReturnModel<User>.Fail("Böyle bir kullanıcı bulunamadı",HttpStatusCode.NotFound);
        }
        return ReturnModel<User>.Success(user);
    }

    public async Task<ReturnModel<User>> LoginAsync(LoginRequestDto request)
    {
        var userExist = await _userManager.FindByEmailAsync(request.Email);
        if (userExist is null)
        {
            return ReturnModel<User>.Fail("Bu emaile ait bir kullanıcı yok", HttpStatusCode.NotFound);
        }
        var result = await _userManager.CheckPasswordAsync(userExist, request.Password);
        if (result is false)
        {
            return ReturnModel<User>.Fail("Hatalı Şifre");
        }
        return ReturnModel<User>.Success(userExist);
    }

    public async Task<ReturnModel> UpdateAsync(string id, UpdateRequestDto request)
    {
        var user = await _userManager.FindByIdAsync(id);
        if(user is null)
        {
            return ReturnModel.Fail("Idye ait kullanıcı bulunamadı", HttpStatusCode.NotFound);
        }

        user.UserName = request.Username;
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;

        var result = await _userManager.UpdateAsync(user);
        if (result.Succeeded is false)
        {
            return ReturnModel.Fail("Güncelleme Başarısız");
        }
        return ReturnModel.Success(HttpStatusCode.NoContent);

    }
}
