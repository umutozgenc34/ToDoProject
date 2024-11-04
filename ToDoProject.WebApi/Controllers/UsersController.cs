using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoProject.Model.Users.Dtos.Request;
using ToDoProject.Service.Users.Abstracts;
using ToDoProject.Service.Users.Concretes;

namespace ToDoProject.WebApi.Controllers;

public class UsersController(IUserService userService) : CustomBaseController
{
    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] RegisterRequestDto request) => CreateActionResult(await userService
        .CreateUserAsync(request));
    
    [HttpGet("getbyemail")]
    public async Task<IActionResult> GetByEmail([FromQuery] string email) => CreateActionResult(await userService.GetByEmailAsync(email));

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromQuery] string id) => CreateActionResult(await userService.DeleteAsync(id));

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromQuery] string id, [FromBody] UpdateRequestDto request) => CreateActionResult(await userService
        .UpdateAsync(id, request));

    [HttpPut("changepassword")]
    public async Task<IActionResult> ChangePassword(string id, ChangePasswordRequestDto request) => CreateActionResult(await userService
        .ChangePasswordAsync(id, request));
    



}
