using Moq;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ToDoProject.Service.Users.Concretes;
using ToDoProject.Service.Users.Rules;
using ToDoProject.Model.Users.Dtos.Request;
using ToDoProject.Model.Users.Entity;
using Core.Entities.ReturnModels;
using ToDoProject.Service.Users.Abstracts;
using Core.Exceptions;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Service.Test;

//[TestFixture]
public class UserTest
{
    //private Mock<UserManager<User>> _mockUserManager;
    //private Mock<UserBusinessRules> _mockUserBusinessRules;
    //private UserService _userService;

    //[SetUp]
    //public void SetUp()
    //{
    //    _mockUserManager = new Mock<UserManager<User>>(Mock.Of<IUserStore<User>>(),
    //        Mock.Of<IOptions<IdentityOptions>>(),
    //        Mock.Of<IPasswordHasher<User>>(),
    //        new List<IUserValidator<User>>(),
    //        new List<IPasswordValidator<User>>(),
    //        Mock.Of<ILookupNormalizer>(),
    //        Mock.Of<IdentityErrorDescriber>(),
    //        Mock.Of<IServiceProvider>(),
    //        Mock.Of<ILogger<UserManager<User>>>());

    //    _mockUserBusinessRules = new Mock<UserBusinessRules>();

    //    _userService = new UserService(_mockUserManager.Object, _mockUserBusinessRules.Object);
    //}

    //[Test]
    //public async Task ChangePasswordAsync_ShouldReturnSuccess_WhenPasswordChanged()
    //{
    //    // Arrange
    //    var id = "user123";
    //    var request = new ChangePasswordRequestDto { OldPassword = "oldPassword", NewPassword = "newPassword" };
    //    var user = new User { Id = id, UserName = "testuser", Email = "test@test.com" };
    //    _mockUserManager.Setup(um => um.FindByIdAsync(id)).ReturnsAsync(user);
    //    _mockUserBusinessRules.Setup(ubr => ubr.CheckUserExists(user));
    //    _mockUserManager.Setup(um => um.ChangePasswordAsync(user, request.OldPassword, request.NewPassword))
    //        .ReturnsAsync(IdentityResult.Success);

    //    // Act
    //    var result = await _userService.ChangePasswordAsync(id, request);

    //    // Assert
    //    Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
    //}

    //[Test]
    //public async Task CreateUserAsync_ShouldReturnSuccess_WhenUserCreated()
    //{
    //    // Arrange
    //    var request = new RegisterRequestDto { FirstName = "John", Lastname = "Doe", Email = "john.doe@test.com", Username = "johndoe", Password = "password123" };
    //    var user = new User { Id = "user123", UserName = request.Username, FirstName = request.FirstName, LastName = request.Lastname, Email = request.Email };
    //    _mockUserManager.Setup(um => um.CreateAsync(It.IsAny<User>(), request.Password)).ReturnsAsync(IdentityResult.Success);

    //    // Act
    //    var result = await _userService.CreateUserAsync(request);

    //    // Assert
    //    Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);
    //    Assert.AreEqual(user, result.Data);
    //}

    //[Test]
    //public async Task DeleteAsync_ShouldReturnNoContent_WhenUserDeleted()
    //{
    //    // Arrange
    //    var id = "user123";
    //    var user = new User { Id = id, UserName = "testuser", Email = "test@test.com" };
    //    _mockUserManager.Setup(um => um.FindByIdAsync(id)).ReturnsAsync(user);
    //    _mockUserBusinessRules.Setup(ubr => ubr.CheckUserExists(user));
    //    _mockUserManager.Setup(um => um.DeleteAsync(user)).ReturnsAsync(IdentityResult.Success);

    //    // Act
    //    var result = await _userService.DeleteAsync(id);

    //    // Assert
    //    Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
    //}

    //[Test]
    //public async Task GetAllAsync_ShouldReturnUsers_WhenUsersExist()
    //{
    //    // Arrange
    //    var users = new List<User> { new User { Id = "user123", UserName = "testuser", Email = "test@test.com" } };
    //    _mockUserManager.Setup(um => um.GetUsersInRoleAsync("User")).ReturnsAsync(users);

    //    // Act
    //    var result = await _userService.GetAllAsync();

    //    // Assert
    //    Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
    //    Assert.AreEqual(1, result.Data.Count);
    //}

    //[Test]
    //public async Task GetByEmailAsync_ShouldReturnUser_WhenUserFound()
    //{
    //    // Arrange
    //    var email = "test@test.com";
    //    var user = new User { Id = "user123", UserName = "testuser", Email = email };
    //    _mockUserManager.Setup(um => um.FindByEmailAsync(email)).ReturnsAsync(user);
    //    _mockUserBusinessRules.Setup(ubr => ubr.CheckUserExists(user));

    //    // Act
    //    var result = await _userService.GetByEmailAsync(email);

    //    // Assert
    //    Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
    //    Assert.AreEqual(user, result.Data);
    //}

    //[Test]
    //public async Task LoginAsync_ShouldReturnUser_WhenCredentialsAreValid()
    //{
    //    // Arrange
    //    var request = new LoginRequestDto { Email = "test@test.com", Password = "password123" };
    //    var user = new User { Id = "user123", UserName = "testuser", Email = request.Email };
    //    _mockUserManager.Setup(um => um.FindByEmailAsync(request.Email)).ReturnsAsync(user);
    //    _mockUserManager.Setup(um => um.CheckPasswordAsync(user, request.Password)).ReturnsAsync(true);
    //    _mockUserBusinessRules.Setup(ubr => ubr.CheckUserExists(user));
    //    _mockUserBusinessRules.Setup(ubr => ubr.PasswordIsValid(true));

    //    // Act
    //    var result = await _userService.LoginAsync(request);

    //    // Assert
    //    Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
    //    Assert.AreEqual(user, result.Data);
    //}

    //[Test]
    //public async Task UpdateAsync_ShouldReturnNoContent_WhenUserUpdated()
    //{
    //    // Arrange
    //    var id = "user123";
    //    var request = new UpdateRequestDto { Username = "updateduser", FirstName = "Updated", LastName = "Name" };
    //    var user = new User { Id = id, UserName = "testuser", FirstName = "Test", LastName = "User", Email = "test@test.com" };
    //    _mockUserManager.Setup(um => um.FindByIdAsync(id)).ReturnsAsync(user);
    //    _mockUserBusinessRules.Setup(ubr => ubr.CheckUserExists(user));
    //    _mockUserManager.Setup(um => um.UpdateAsync(user)).ReturnsAsync(IdentityResult.Success);

    //    // Act
    //    var result = await _userService.UpdateAsync(id, request);

    //    // Assert
    //    Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
    //}
}
