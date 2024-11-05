using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoProject.Model.Users.Dtos.Request;
using ToDoProject.Service.Roles.Abstracts;

namespace ToDoProject.WebApi.Controllers;

public class RolesController(IRoleService roleService) : CustomBaseController
{
    [HttpPost("AddRole")]
    public async Task<IActionResult> AddRoleAsync([FromBody] string roleName) => CreateActionResult(await roleService.AddRoleAsync(roleName));

    [HttpPost("AddRoleToUser")]
    public async Task<IActionResult> AddRoleToUser([FromBody] RoleAddToUserRequestDto request) => CreateActionResult(await roleService
        .AddRoleToUser(request));
    
    [HttpGet("GetAllRolesByUserId/{userId}")]
    public async Task<IActionResult> GetAllRolesByUserId(string userId) => CreateActionResult(await roleService.GetAllRolesByUserId(userId));
   
}
