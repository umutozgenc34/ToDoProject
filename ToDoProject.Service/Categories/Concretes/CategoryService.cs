﻿
using AutoMapper;
using Core.Entities.ReturnModels;
using Microsoft.EntityFrameworkCore;
using System.Net;
using ToDoProject.Model.Categories.Dtos.Create;
using ToDoProject.Model.Categories.Dtos.Global;
using ToDoProject.Model.Categories.Dtos.Update;
using ToDoProject.Model.Categories.Entity;
using ToDoProject.Repository.Categories.Abstracts;
using ToDoProject.Repository.UnitOfWorks.Abstracts;
using ToDoProject.Service.Categories.Abstracts;

namespace ToDoProject.Service.Categories.Concretes;

public class CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper) : ICategoryService
{
    public async Task<ReturnModel<List<CategoryDto>>> GetAllAsync()
    {
        var categories = await categoryRepository.GetAll().ToListAsync();
        var categoriesAsDto = mapper.Map<List<CategoryDto>>(categories);
        return ReturnModel<List<CategoryDto>>.Success(categoriesAsDto);
    }

    public async Task<ReturnModel<CategoryDto>> GetByIdAsync(int id)
    {
        var category = await categoryRepository.GetByIdAsync(id);
        if (category is null)
        {
            ReturnModel<CategoryDto>.Fail("Kategori Bulunamadı",HttpStatusCode.NotFound);
        }

        var categoryAsDto = mapper.Map<CategoryDto>(category);

        return ReturnModel<CategoryDto>.Success(categoryAsDto);
    }

    public async Task<ReturnModel<CategoryWithTodosDto>> GetCategoryWithToDosAsync(int categoryId)
    {
        var category = await categoryRepository.GetCategoryWithTodosAsync(categoryId);
        if (category == null)
        {
            return ReturnModel<CategoryWithTodosDto>.Fail("Kullanıcı bulunamadı", HttpStatusCode.NotFound);
        }

        var categoryAsDto = mapper.Map<CategoryWithTodosDto>(category);

        return ReturnModel<CategoryWithTodosDto>.Success(categoryAsDto);
    }
    public async Task<ReturnModel<List<CategoryWithTodosDto>>> GetCategoryWithToDosAsync()
    {
        var category = await categoryRepository.GetCategoryWithTodos().ToListAsync();

        var categoryAsDto = mapper.Map<List<CategoryWithTodosDto>>(category);

        return ReturnModel<List<CategoryWithTodosDto>>.Success(categoryAsDto);
    }

    public async Task<ReturnModel<int>> CreateAsync(CreateCategoryRequestDto request)
    {
        var anyCategory = await categoryRepository.Where(x => x.Name == request.Name).AnyAsync();
        if (anyCategory)
        {
            return ReturnModel<int>.Fail("Categori ismi veritabanında bulunmamaktadır", HttpStatusCode.NotFound);
        }

        var newCategory = mapper.Map<Category>(request);
        await categoryRepository.AddAsync(newCategory);
        await unitOfWork.SaveChangesAsync();

        return ReturnModel<int>.Success(newCategory.Id,HttpStatusCode.Created);
    }

    public async Task<ReturnModel> DeleteAsync(int id)
    {
        var category = await categoryRepository.GetByIdAsync(id);
        if (category is null)
        {
            return ReturnModel.Fail("Kategori bulunamadı", HttpStatusCode.NotFound);
        }

        categoryRepository.Delete(category);
        await unitOfWork.SaveChangesAsync();

        return ReturnModel.Success(HttpStatusCode.NoContent);
    }

    public async Task<ReturnModel> UpdateAsync(int id, UpdateCategoryRequestDto request)
    {
        var category = await categoryRepository.GetByIdAsync(id);
        if (category is null)
        {
            return ReturnModel.Fail("Böyle bir kategori bulunamadı", HttpStatusCode.NotFound);
        }

        var isCategoryNameExist = await categoryRepository.Where(x => x.Name == request.Name && x.Id != category.Id).AnyAsync();
        if (isCategoryNameExist)
        {
            return ReturnModel.Fail("Category veritabanında bulunmaktadır", HttpStatusCode.BadRequest);
        }

        category = mapper.Map(request, category);

        categoryRepository.Update(category);
        await unitOfWork.SaveChangesAsync();

        return ReturnModel.Success(HttpStatusCode.NoContent);
    }
}
