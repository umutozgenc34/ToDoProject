using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoProject.Model.ToDos.Dtos.Create.Request;
using ToDoProject.Model.ToDos.Dtos.Update;
using ToDoProject.Service.ToDoS.Abstracts;

namespace ToDoProject.WebApi.Controllers
{
    [Authorize]
    public class ToDosController(IToDoService toDoService) :  CustomBaseController
    {
        [Authorize(Roles ="Admin,SuperAdmin")]
        [HttpGet]
        public async Task<IActionResult> GetAll() => CreateActionResult(await toDoService.GetAllListAsync());


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id) => CreateActionResult(await toDoService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateToDoRequestDto request) => CreateActionResult(await toDoService.
            CreateAsync(request));

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody]UpdateToDoRequestDto request) => CreateActionResult(await toDoService.
            UpdateAsync(id, request));

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id) => CreateActionResult(await toDoService.DeleteAsync(id));

        [HttpGet("getallbytitlecontains")]
        public async Task<IActionResult> GetAllByTitleContains([FromQuery]string text) => CreateActionResult(await toDoService.GetAllByTitleContainsAsync(text));

        [HttpGet("getallbyuserid")]
        public async Task<IActionResult> GetAllByUserId([FromRoute]string id) => CreateActionResult(await toDoService.GetAllByUserIdAsync(id));

        [HttpGet("owntodos")]
        public async Task<IActionResult> OwnTodos()
        {
            string userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("Kullanıcı bulunamadı.");
            }
            return CreateActionResult(await toDoService.GetAllByUserIdAsync(userId));

        }

        [HttpGet("owntodoscompletefilter")]
        public async Task<IActionResult> OwnTodos([FromQuery] bool? completed = null)
        {
            
            string userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("Kullanıcı bulunamadı.");
            }

            
            return CreateActionResult(await toDoService.GetFilterOwnTodosAsync(userId, completed));

            
            
        }



    }
}
