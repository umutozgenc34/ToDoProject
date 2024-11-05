using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoProject.Model.Categories.Dtos.Create;
using ToDoProject.Model.Categories.Dtos.Update;
using ToDoProject.Service.Categories.Abstracts;

namespace ToDoProject.WebApi.Controllers;

[Authorize]
public class CategoriesController(ICategoryService categoryService) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetCategories() => CreateActionResult(await categoryService.GetAllAsync());
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCategory([FromRoute]int id) => CreateActionResult(await categoryService.GetByIdAsync(id));
    [HttpGet("{id:int}/todos")]
    public async Task<IActionResult> GetCategoryWithTodos([FromRoute]int id) => CreateActionResult(await categoryService
        .GetCategoryWithToDosAsync(id));

    [HttpGet("todos")]
    public async Task<IActionResult> GetCategoryWithTodos() => CreateActionResult(await categoryService
        .GetCategoryWithToDosAsync());


    [Authorize(Roles = "Admin, SuperAdmin")]
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody]CreateCategoryRequestDto request) => CreateActionResult(await categoryService
        .CreateAsync(request));

    [Authorize(Roles = "Admin, SuperAdmin")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCategory([FromRoute]int id, [FromBody]UpdateCategoryRequestDto request) => CreateActionResult
        (await categoryService.UpdateAsync(id, request));

    [Authorize(Roles = "Admin, SuperAdmin")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCategory([FromRoute]int id) => CreateActionResult(await categoryService.DeleteAsync(id));
}

