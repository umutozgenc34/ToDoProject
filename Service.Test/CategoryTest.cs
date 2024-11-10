
using Moq;
using NUnit.Framework;
using AutoMapper;
using ToDoProject.Service.Categories.Concretes;
using ToDoProject.Repository.Categories.Abstracts;
using ToDoProject.Repository.UnitOfWorks.Abstracts;
using ToDoProject.Service.Categories.Rules;
using Core.Entities.ReturnModels;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using ToDoProject.Model.Categories.Dtos.Create;
using ToDoProject.Model.Categories.Dtos.Global;
using ToDoProject.Model.Categories.Dtos.Update;
using ToDoProject.Model.Categories.Entity;

namespace Service.Test;
//[TestFixture]
public class CategoryTest
{
    //private Mock<ICategoryRepository> _categoryRepositoryMock;
    //private Mock<IUnitOfWork> _unitOfWorkMock;
    //private Mock<IMapper> _mapperMock;
    //private Mock<CategoryBusinessRules> _businessRulesMock;
    //private CategoryService _categoryService;

    //[SetUp]
    //public void Setup()
    //{
        
    //    _categoryRepositoryMock = new Mock<ICategoryRepository>();
    //    _unitOfWorkMock = new Mock<IUnitOfWork>();
    //    _mapperMock = new Mock<IMapper>();
    //    _businessRulesMock = new Mock<CategoryBusinessRules>();

        
    //    _categoryService = new CategoryService(
    //        _categoryRepositoryMock.Object,
    //        _unitOfWorkMock.Object,
    //        _mapperMock.Object,
    //        _businessRulesMock.Object);
    //}

    //[Test]
    //public async Task GetAllAsync_ShouldReturnCategories_WhenCategoriesExist()
    //{
    //    // Arrange: 
    //    var categories = new List<Category> { new Category { Id = 1, Name = "Test Category" } };
    //    //var categoryDtos = new List<CategoryDto> { new CategoryDto { Id = 1, Name = "Test Category" } };

    //    
    //    _categoryRepositoryMock.Setup(repo => repo.GetAll()).Returns(categories.AsQueryable());
    //    _mapperMock.Setup(mapper => mapper.Map<List<CategoryDto>>(categories)).Returns(categoryDtos);

    //    // Act: 
    //    var result = await _categoryService.GetAllAsync();

    //    // Assert: 
    //    Assert.IsNotNull(result);
    //    Assert.IsTrue(result.IsSuccess);
    //    //Assert.AreEqual(categoryDtos.Count, result.Data.Count);
    //}

    //[Test]
    //public async Task CreateAsync_ShouldReturnSuccess_WhenCategoryIsCreated()
    //{
    //    // Arrange
    //    //var request = new CreateCategoryRequestDto { Name = "New Category" };
    //    var category = new Category { Id = 1, Name = "New Category" };

    //    // 
    //    //_categoryRepositoryMock.Setup(repo => repo.Where(It.IsAny<Func<Category, bool>>())).Returns(Enumerable.Empty<Category>().AsQueryable());
    //    //_mapperMock.Setup(mapper => mapper.Map<Category>(request)).Returns(category);
    //    //_categoryRepositoryMock.Setup(repo => repo.AddAsync(category)).Returns(Task.CompletedTask);
    //    //_unitOfWorkMock.Setup(uow => uow.SaveChangesAsync()).Returns(Task.CompletedTask);

    //    // Act
    //    var result = await _categoryService.CreateAsync(request);

    //    // Assert
    //    Assert.IsNotNull(result);
    //    Assert.IsTrue(result.IsSuccess);
    //    Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);
    //}

    //[Test]
    //public async Task UpdateAsync_ShouldReturnSuccess_WhenCategoryIsUpdated()
    //{
    //    // Arrange
    //    var request = new UpdateCategoryRequestDto { Name = "Updated Category" };
    //    var category = new Category { Id = 1, Name = "Old Category" };

    //    // 
    //    _categoryRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(category);
    //    _businessRulesMock.Setup(br => br.CategoryExists(category));
    //    _categoryRepositoryMock.Setup(repo => repo.Where(It.IsAny<Func<Category, bool>>())).Returns(Enumerable.Empty<Category>().AsQueryable());
    //    _mapperMock.Setup(mapper => mapper.Map(request, category)).Returns(category);
    //    _categoryRepositoryMock.Setup(repo => repo.Update(category));
    //    _unitOfWorkMock.Setup(uow => uow.SaveChangesAsync()).Returns();

    //    // Act
    //    var result = await _categoryService.UpdateAsync(1, request);

    //    // Assert
    //    Assert.IsNotNull(result);
    //    Assert.IsTrue(result.IsSuccess);
    //    Assert.AreEqual(HttpStatusCode.NoContent, result.Status);
    //}

    //[Test]
    //public async Task DeleteAsync_ShouldReturnSuccess_WhenCategoryIsDeleted()
    //{
    //    // Arrange
    //    var category = new Category { Id = 1, Name = "Test Category" };

    //    // Mock işlemleri
    //    _categoryRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(category);
    //    _businessRulesMock.Setup(br => br.CategoryExists(category));
    //    _categoryRepositoryMock.Setup(repo => repo.Delete(category));
    //    _unitOfWorkMock.Setup(uow => uow.SaveChangesAsync()).Returns(Task.CompletedTask);

    //    // Act
    //    var result = await _categoryService.DeleteAsync(1);

    //    // Assert
    //    Assert.IsNotNull(result);
    //    Assert.IsTrue(result.IsSuccess);
    //    Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
    //}
}
