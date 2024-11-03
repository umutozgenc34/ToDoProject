using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoProject.Model.Categories.Dtos.Create;
using ToDoProject.Model.Categories.Dtos.Update;
using ToDoProject.Service.Categories.Abstracts;

namespace ToDoProject.WebApi.Controllers;

public class CategoriesController(ICategoryService categoryService) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetCategories() => CreateActionResult(await categoryService.GetAllAsync());
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCategory(int id) => CreateActionResult(await categoryService.GetByIdAsync(id));
    [HttpGet("{id:int}/todos")]
    public async Task<IActionResult> GetCategoryWithProducts(int id) => CreateActionResult(await categoryService
        .GetCategoryWithToDosAsync(id));

    [HttpGet("todos")]
    public async Task<IActionResult> GetCategoryWithProducts() => CreateActionResult(await categoryService
        .GetCategoryWithToDosAsync());

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request) => CreateActionResult(await categoryService
        .CreateAsync(request));
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryRequestDto request) => CreateActionResult
        (await categoryService.UpdateAsync(id, request));
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCategory(int id) => CreateActionResult(await categoryService.DeleteAsync(id));
}

