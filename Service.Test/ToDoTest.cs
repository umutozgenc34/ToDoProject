using AutoMapper;
using Core.Entities.ReturnModels;
using Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ToDoProject.Model.ToDos.Dtos.Create.Request;
using ToDoProject.Model.ToDos.Dtos.Create.Response;
using ToDoProject.Model.ToDos.Dtos.Global;
using ToDoProject.Model.ToDos.Dtos.Update;
using ToDoProject.Model.ToDos.Entity;
using ToDoProject.Repository.ToDos.Abstracts;
using ToDoProject.Repository.UnitOfWorks.Abstracts;
using ToDoProject.Service.ToDoS.Concretes;
using ToDoProject.Service.ToDoS.Rules;

namespace Service.Test;
//[TestFixture]
public class ToDoTest
{
    //private Mock<IToDoRepository> _mockToDoRepository;
    //private Mock<IUnitOfWork> _mockUnitOfWork;
    //private Mock<IMapper> _mockMapper;
    //private Mock<ToDoBusinessRules> _mockBusinessRules;
    //private ToDoService _toDoService;

    //[SetUp]
    //public void SetUp()
    //{
    //    _mockToDoRepository = new Mock<IToDoRepository>();
    //    _mockUnitOfWork = new Mock<IUnitOfWork>();
    //    _mockMapper = new Mock<IMapper>();
    //    _mockBusinessRules = new Mock<ToDoBusinessRules>();
    //    _toDoService = new ToDoService(
    //        _mockToDoRepository.Object,
    //        _mockUnitOfWork.Object,
    //        _mockMapper.Object,
    //        _mockBusinessRules.Object
    //    );
    //}

    //[Test]
    //public async Task CreateAsync_ShouldReturnSuccess_WhenToDoIsCreated()
    //{
    //    // Arrange
    //    var request = new CreateToDoRequestDto { Title = "Test ToDo" };
    //    var toDo = new ToDo { Id = Guid.NewGuid(), Title = "Test ToDo" };
    //    var toDoResponseDto = new CreateToDoResponseDto { Id = toDo.Id, Title = toDo.Title };

    //    _mockToDoRepository.Setup(repo => repo.Where(It.IsAny<Func<ToDo, bool>>()).AnyAsync()).ReturnsAsync(false);
    //    _mockMapper.Setup(m => m.Map<ToDo>(It.IsAny<CreateToDoRequestDto>())).Returns(toDo);
    //    _mockMapper.Setup(m => m.Map<CreateToDoResponseDto>(It.IsAny<ToDo>())).Returns(toDoResponseDto);

    //    // Act
    //    var result = await _toDoService.CreateAsync(request);

    //    // Assert
    //    Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);
    //    Assert.AreEqual(toDoResponseDto, result.Data);
    //}

    //[Test]
    //public async Task DeleteAsync_ShouldReturnSuccess_WhenToDoIsDeleted()
    //{
    //    // Arrange
    //    var id = Guid.NewGuid();
    //    var toDo = new ToDo { Id = id };
    //    _mockToDoRepository.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync(toDo);
    //    _mockBusinessRules.Setup(br => br.ToDoExists(It.IsAny<ToDo>()));

    //    // Act
    //    var result = await _toDoService.DeleteAsync(id);

    //    // Assert
    //    Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
    //}

    //[Test]
    //public async Task GetAllByTitleContainsAsync_ShouldReturnToDos_WhenTitleContainsText()
    //{
    //    // Arrange
    //    var text = "Test";
    //    var toDos = new List<ToDo> { new ToDo { Id = Guid.NewGuid(), Title = "Test ToDo" } };
    //    var toDoDto = new ToDoDto { Id = toDos[0].Id, Title = toDos[0].Title };
    //    _mockToDoRepository.Setup(repo => repo.Where(It.IsAny<Func<ToDo, bool>>()).ToListAsync()).ReturnsAsync(toDos);
    //    _mockBusinessRules.Setup(br => br.ToDoDoesNotExist(It.IsAny<List<ToDo>>()));
    //    _mockMapper.Setup(m => m.Map<List<ToDoDto>>(It.IsAny<List<ToDo>>())).Returns(new List<ToDoDto> { toDoDto });

    //    // Act
    //    var result = await _toDoService.GetAllByTitleContainsAsync(text);

    //    // Assert
    //    Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
    //    Assert.AreEqual(1, result.Data.Count);
    //}

    //[Test]
    //public async Task GetAllByUserIdAsync_ShouldReturnToDos_WhenUserIdIsValid()
    //{
    //    // Arrange
    //    var userId = "user123";
    //    var toDos = new List<ToDo> { new ToDo { Id = Guid.NewGuid(), UserId = userId } };
    //    var toDoDto = new ToDoDto { Id = toDos[0].Id, UserId = toDos[0].UserId };
    //    _mockToDoRepository.Setup(repo => repo.Where(It.IsAny<Func<ToDo, bool>>()).ToListAsync()).ReturnsAsync(toDos);
    //    _mockBusinessRules.Setup(br => br.ToDoDoesNotExist(It.IsAny<List<ToDo>>()));
    //    _mockMapper.Setup(m => m.Map<List<ToDoDto>>(It.IsAny<List<ToDo>>())).Returns(new List<ToDoDto> { toDoDto });

    //    // Act
    //    var result = await _toDoService.GetAllByUserIdAsync(userId);

    //    // Assert
    //    Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
    //    Assert.AreEqual(1, result.Data.Count);
    //}

    //[Test]
    //public async Task GetByIdAsync_ShouldReturnToDo_WhenIdIsValid()
    //{
    //    // Arrange
    //    var id = Guid.NewGuid();
    //    var toDo = new ToDo { Id = id };
    //    var toDoDto = new ToDoDto { Id = toDo.Id };
    //    _mockToDoRepository.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync(toDo);
    //    _mockBusinessRules.Setup(br => br.ToDoExists(It.IsAny<ToDo>()));
    //    _mockMapper.Setup(m => m.Map<ToDoDto>(It.IsAny<ToDo>())).Returns(toDoDto);

    //    // Act
    //    var result = await _toDoService.GetByIdAsync(id);

    //    // Assert
    //    Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
    //    Assert.AreEqual(toDoDto, result.Data);
    //}

    //[Test]
    //public async Task UpdateAsync_ShouldReturnNoContent_WhenToDoIsUpdated()
    //{
    //    // Arrange
    //    var id = Guid.NewGuid();
    //    var toDo = new ToDo { Id = id, Title = "Old Title" };
    //    var request = new UpdateToDoRequestDto { Title = "New Title" };
    //    _mockToDoRepository.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync(toDo);
    //    _mockToDoRepository.Setup(repo => repo.Where(It.IsAny<Func<ToDo, bool>>()).AnyAsync()).ReturnsAsync(false);
    //    _mockMapper.Setup(m => m.Map(It.IsAny<UpdateToDoRequestDto>(), It.IsAny<ToDo>())).Returns(new ToDo { Id = id, Title = "New Title" });

    //    // Act
    //    var result = await _toDoService.UpdateAsync(id, request);

    //    // Assert
    //    Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
    //}

    //[Test]
    //public async Task GetFilterOwnTodosAsync_ShouldReturnFilteredTodos_WhenFilterIsApplied()
    //{
    //    // Arrange
    //    var userId = "user123";
    //    var todos = new List<ToDo> { new ToDo { Id = Guid.NewGuid(), UserId = userId, Completed = true } };
    //    var toDoDto = new ToDoDto { Id = todos[0].Id, UserId = todos[0].UserId };
    //    _mockToDoRepository.Setup(repo => repo.Where(It.IsAny<Func<ToDo, bool>>()).ToListAsync()).ReturnsAsync(todos);
    //    _mockMapper.Setup(m => m.Map<List<ToDoDto>>(It.IsAny<List<ToDo>>())).Returns(new List<ToDoDto> { toDoDto });

    //    // Act
    //    var result = await _toDoService.GetFilterOwnTodosAsync(userId, true);

    //    // Assert
    //    Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
    //    Assert.AreEqual(1, result.Data.Count);
    //}
}
