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
using ToDoProject.Service.Users.Rules;

namespace ToDoProject.Service.Users.Concretes;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly UserBusinessRules _userBusinessRules;
    public UserService(UserManager<User> userManager, UserBusinessRules userBusinessRules)
    {
        _userManager = userManager;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<ReturnModel> ChangePasswordAsync(string id, ChangePasswordRequestDto request)
    {
        var user = await _userManager.FindByIdAsync(id);
        _userBusinessRules.CheckUserExists(user);
        var result = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);
        _userBusinessRules.PasswordChangeSucceeded(result);
        
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
        _userBusinessRules.CheckUserExists(user);
        await _userManager.DeleteAsync(user);

        return ReturnModel.Success(HttpStatusCode.NoContent);
    }

    public async Task <ReturnModel<User>> GetByEmailAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        _userBusinessRules.CheckUserExists(user);

        return ReturnModel<User>.Success(user);
    }

    public async Task<ReturnModel<User>> LoginAsync(LoginRequestDto request)
    {
        var userExist = await _userManager.FindByEmailAsync(request.Email);
        _userBusinessRules.CheckUserExists(userExist);

        var result = await _userManager.CheckPasswordAsync(userExist, request.Password);
        _userBusinessRules.PasswordIsValid(result);

        return ReturnModel<User>.Success(userExist);
    }

    public async Task<ReturnModel> UpdateAsync(string id, UpdateRequestDto request)
    {
        var user = await _userManager.FindByIdAsync(id);
        _userBusinessRules.CheckUserExists(user);

        user.UserName = request.Username;
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;

        var result = await _userManager.UpdateAsync(user);
        _userBusinessRules.UpdateIsSuccessful(result);

        return ReturnModel.Success(HttpStatusCode.NoContent);

    }
}
