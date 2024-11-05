using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoProject.Model.Users.Dtos.Request;
using ToDoProject.Service.Roles.Abstracts;

namespace ToDoProject.WebApi.Controllers;

[Authorize]
public class RolesController(IRoleService roleService) : CustomBaseController
{
    [Authorize(Roles = "Admin, SuperAdmin")]
    [HttpPost("AddRole")]
    public async Task<IActionResult> AddRoleAsync([FromBody] string roleName) => CreateActionResult(await roleService.AddRoleAsync(roleName));

    [Authorize(Roles = "SuperAdmin")]
    [HttpPost("AddRoleToUser")]
    public async Task<IActionResult> AddRoleToUser([FromBody] RoleAddToUserRequestDto request) => CreateActionResult(await roleService
        .AddRoleToUser(request));
    
    [HttpGet("GetAllRolesByUserId/{userId}")]
    public async Task<IActionResult> GetAllRolesByUserId([FromRoute]string userId) => CreateActionResult(await roleService.GetAllRolesByUserId(userId));
   
}
