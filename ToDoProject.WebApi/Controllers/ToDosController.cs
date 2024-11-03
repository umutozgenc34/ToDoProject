using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoProject.Model.ToDos.Dtos.Create.Request;
using ToDoProject.Model.ToDos.Dtos.Update;
using ToDoProject.Service.ToDoS.Abstracts;

namespace ToDoProject.WebApi.Controllers
{
   
    public class ToDosController(IToDoService toDoService) :  CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() => CreateActionResult(await toDoService.GetAllListAsync());


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id) => CreateActionResult(await toDoService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(CreateToDoRequestDto request) => CreateActionResult(await toDoService.
            CreateAsync(request));

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateToDoRequestDto request) => CreateActionResult(await toDoService.
            UpdateAsync(id, request));

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id) => CreateActionResult(await toDoService.DeleteAsync(id));
    }
}
