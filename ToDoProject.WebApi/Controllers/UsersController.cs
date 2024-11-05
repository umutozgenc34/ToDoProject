
using Core.Entities.ReturnModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoProject.Model.Tokens.Dtos.Response;
using ToDoProject.Model.Users.Dtos.Request;
using ToDoProject.Service.Authentication.Abstracts;
using ToDoProject.Service.Users.Abstracts;
using ToDoProject.Service.Users.Concretes;

namespace ToDoProject.WebApi.Controllers;
[Authorize]
public class UsersController(IUserService userService ) : CustomBaseController
{
    [HttpGet("getbyemail")]
    public async Task<IActionResult> GetByEmail([FromQuery] string email) => CreateActionResult(await userService.GetByEmailAsync(email));

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromQuery] string id) => CreateActionResult(await userService.DeleteAsync(id));

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromQuery] string id, [FromBody] UpdateRequestDto request) => CreateActionResult(await userService
        .UpdateAsync(id, request));

    [HttpPut("changepassword")]
    public async Task<IActionResult> ChangePassword([FromQuery]string id, [FromBody]ChangePasswordRequestDto request) => CreateActionResult(await userService
        .ChangePasswordAsync(id, request));

}
