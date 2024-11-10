using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using ToDoProject.Service.Authentication.Concretes;
using ToDoProject.Service.Authentication.Rules;
using ToDoProject.Service.JWT.Abstracts;
using ToDoProject.Service.Users.Abstracts;
using ToDoProject.Model.Tokens.Dtos.Response;
using ToDoProject.Model.Users.Dtos.Request;
using ToDoProject.Model.Users.Entity;
using Core.Entities.ReturnModels;
using Core.Exceptions;

namespace Service.Test;
//[TestFixture]
public class AuthenticationTest
{
    //private Mock<IUserService> _mockUserService;
    //private Mock<IJwtService> _mockJwtService;
    //private Mock<AuthenticationBusinessRules> _mockBusinessRules;
    //private AuthenticationServicee _authenticationService;

    //[SetUp]
    //public void SetUp()
    //{
    //    _mockUserService = new Mock<IUserService>();
    //    _mockJwtService = new Mock<IJwtService>();
    //    _mockBusinessRules = new Mock<AuthenticationBusinessRules>();
    //    _authenticationService = new AuthenticationServicee(
    //        _mockUserService.Object,
    //        _mockJwtService.Object,
    //        _mockBusinessRules.Object
    //    );
    //}

    //[Test]
    //public async Task LoginByTokenAsync_ShouldReturnToken_WhenLoginSuccessful()
    //{
    //    // Arrange
    //    var loginRequest = new LoginRequestDto { Email = "test@test.com", Password = "password123" };
    //    var user = new User { Id = "user123", UserName = "testuser", Email = loginRequest.Email };
    //    var tokenResponse = new TokenResponseDto { Token = "validToken" };

    //    // Mock business rules validation
    //    _mockBusinessRules.Setup(br => br.ValidateLoginRequest(loginRequest));

    //    // Mock user service login
    //    _mockUserService.Setup(us => us.LoginAsync(loginRequest)).ReturnsAsync(ReturnModel<User>.Success(user));

    //    // Mock JWT service token creation
    //    _mockJwtService.Setup(js => js.CreateToken(user)).ReturnsAsync(tokenResponse);

    //    // Act
    //    var result = await _authenticationService.LoginByTokenAsync(loginRequest);

    //    // Assert
    //    Assert.IsNotNull(result);
    //    Assert.AreEqual("validToken", result.Token);
    //}

    //[Test]
    //public void LoginByTokenAsync_ShouldThrowNotFoundException_WhenLoginFails()
    //{
    //    // Arrange
    //    var loginRequest = new LoginRequestDto { Email = "test@test.com", Password = "wrongPassword" };

    //    // Mock business rules validation
    //    _mockBusinessRules.Setup(br => br.ValidateLoginRequest(loginRequest));

    //    // Mock user service login to return null (indicating failed login)
    //    _mockUserService.Setup(us => us.LoginAsync(loginRequest)).ReturnsAsync(ReturnModel<User>.Failure("User not found"));

    //    // Act & Assert
    //    Assert.ThrowsAsync<NotFoundException>(async () => await _authenticationService.LoginByTokenAsync(loginRequest));
    //}

    //[Test]
    //public async Task RegisterByTokenAsync_ShouldReturnToken_WhenRegisterSuccessful()
    //{
    //    // Arrange
    //    var registerRequest = new RegisterRequestDto
    //    {
    //        FirstName = "John",
    //        Lastname = "Doe",
    //        Email = "john.doe@test.com",
    //        Username = "johndoe",
    //        Password = "password123"
    //    };
    //    var user = new User { Id = "user123", UserName = registerRequest.Username, FirstName = registerRequest.FirstName, LastName = registerRequest.Lastname, Email = registerRequest.Email };
    //    var tokenResponse = new TokenResponseDto { Token = "validToken" };

    //    // Mock business rules validation
    //    _mockBusinessRules.Setup(br => br.ValidateRegisterRequest(registerRequest));

    //    // Mock user service create user
    //    _mockUserService.Setup(us => us.CreateUserAsync(registerRequest)).ReturnsAsync(ReturnModel<User>.Success(user, System.Net.HttpStatusCode.Created));

    //    // Mock JWT service token creation
    //    _mockJwtService.Setup(js => js.CreateToken(user)).ReturnsAsync(tokenResponse);

    //    // Act
    //    var result = await _authenticationService.RegisterByTokenAsync(registerRequest);

    //    // Assert
    //    Assert.IsNotNull(result);
    //    Assert.AreEqual("validToken", result.Token);
    //}

    //[Test]
    //public void RegisterByTokenAsync_ShouldThrowNotFoundException_WhenRegisterFails()
    //{
    //    // Arrange
    //    var registerRequest = new RegisterRequestDto
    //    {
    //        FirstName = "John",
    //        Lastname = "Doe",
    //        Email = "john.doe@test.com",
    //        Username = "johndoe",
    //        Password = "password123"
    //    };

    //    // Mock business rules validation
    //    _mockBusinessRules.Setup(br => br.ValidateRegisterRequest(registerRequest));

    //    // Mock user service create user to return failure
    //    _mockUserService.Setup(us => us.CreateUserAsync(registerRequest)).ReturnsAsync(ReturnModel<User>.Failure("User creation failed"));

    //    // Act & Assert
    //    Assert.ThrowsAsync<NotFoundException>(async () => await _authenticationService.RegisterByTokenAsync(registerRequest));
    //}
}
