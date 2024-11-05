

using Core.Entities.ReturnModels;
using ToDoProject.Model.Users.Dtos.Request;

namespace ToDoProject.Service.Roles.Abstracts;

public interface IRoleService
{
    Task<ReturnModel<string>> AddRoleToUser(RoleAddToUserRequestDto request);

    Task<ReturnModel<List<string>>> GetAllRolesByUserId(string userId);

    Task<ReturnModel<string>> AddRoleAsync(string name);
}
