

using Core.Entities.ReturnModels;
using ToDoProject.Model.Users.Dtos.Request;
using ToDoProject.Model.Users.Entity;

namespace ToDoProject.Service.Users.Abstracts;

public interface IUserService
{
    Task <ReturnModel<User>> CreateUserAsync(RegisterRequestDto request);
    Task <ReturnModel<User>> GetByEmailAsync(string email);
    Task<ReturnModel<User>> LoginAsync(LoginRequestDto request);
    Task<ReturnModel> DeleteAsync(string id);
    Task<ReturnModel> UpdateAsync(string id , UpdateRequestDto request);
    Task<ReturnModel> ChangePasswordAsync(string id, ChangePasswordRequestDto request);

}
