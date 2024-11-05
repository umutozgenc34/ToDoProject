

using AutoMapper;
using Core.Entities.ReturnModels;
using Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Net;
using System.Net.Http.Headers;
using ToDoProject.Model.ToDos.Dtos.Create.Request;
using ToDoProject.Model.ToDos.Dtos.Create.Response;
using ToDoProject.Model.ToDos.Dtos.Global;
using ToDoProject.Model.ToDos.Dtos.Update;
using ToDoProject.Model.ToDos.Entity;
using ToDoProject.Repository.ToDos.Abstracts;
using ToDoProject.Repository.UnitOfWorks.Abstracts;
using ToDoProject.Service.ToDoS.Abstracts;
using ToDoProject.Service.ToDoS.Rules;

namespace ToDoProject.Service.ToDoS.Concretes;

public class ToDoService(IToDoRepository toDoRepository,IUnitOfWork unitOfWork,IMapper mapper,ToDoBusinessRules businessRules) : IToDoService
{
    public async Task<ReturnModel<CreateToDoResponseDto>> CreateAsync(CreateToDoRequestDto request)
    {
        var anyTodo = await toDoRepository.Where(x=> x.Title == request.Title).AnyAsync();
        businessRules.ToDoTitleDoesNotExist(anyTodo);

        var toDo = mapper.Map<ToDo>(request);
        await toDoRepository.AddAsync(toDo);
        await unitOfWork.SaveChangesAsync();

        var toDoResponse = mapper.Map<CreateToDoResponseDto>(toDo);

        return ReturnModel<CreateToDoResponseDto>.Success(toDoResponse, HttpStatusCode.Created);
           
    }

    public async Task<ReturnModel> DeleteAsync(Guid id)
    {
        var toDo = await toDoRepository.GetByIdAsync(id);
        businessRules.ToDoExists(toDo);
        
        toDoRepository.Delete(toDo);
        await unitOfWork.SaveChangesAsync();

        return ReturnModel.Success(HttpStatusCode.NoContent);
    }

    public async Task<ReturnModel<List<ToDoDto>>> GetAllByTitleContainsAsync(string text)
    {
        var toDos = await toDoRepository.Where(x => x.Title.Contains(text)).ToListAsync();
        businessRules.ToDoDoesNotExist(toDos);

        var toDoAsDto = mapper.Map<List<ToDoDto>>(toDos);
      
        return ReturnModel<List<ToDoDto>>.Success(toDoAsDto);
    }

    public async Task<ReturnModel<List<ToDoDto>>> GetAllByUserIdAsync(string userId)
    {
        var toDos = await toDoRepository.Where(x=> x.User.Id == userId).ToListAsync();
        businessRules.ToDoDoesNotExist(toDos);
        var toDoAsDto = mapper.Map<List<ToDoDto>>(toDos);
        return ReturnModel<List<ToDoDto>>.Success(toDoAsDto);
    }

    public async Task<ReturnModel<List<ToDoDto>>> GetAllListAsync()
    {
        var toDos = await toDoRepository.GetAll().ToListAsync();
        var toDoAsDto = mapper.Map<List<ToDoDto>>(toDos);

        return ReturnModel<List<ToDoDto>>.Success(toDoAsDto);
    }

    public async Task<ReturnModel<ToDoDto?>> GetByIdAsync(Guid id)
    {
        var toDo = await toDoRepository.GetByIdAsync(id);
        businessRules.ToDoExists(toDo);

        var toDoAsDto = mapper.Map<ToDoDto>(toDo);
        
        return ReturnModel<ToDoDto?>.Success(toDoAsDto);
    }

    public async Task<ReturnModel<List<ToDoDto>>> GetFilterOwnTodosAsync(string userId, bool? completed = null)
    {
        var todos = await toDoRepository.Where(todo => todo.UserId == userId).ToListAsync();
        todos = CheckCompleted(completed, todos);

        var toDoAsDto = mapper.Map<List<ToDoDto>>(todos);
        return ReturnModel<List<ToDoDto>>.Success(toDoAsDto);
    }

    public async Task<ReturnModel> UpdateAsync(Guid id, UpdateToDoRequestDto request)
    {
        var toDo = await toDoRepository.GetByIdAsync(id);
        businessRules.ToDoExists(toDo);

        var isToDoTitleExist = await toDoRepository.Where(x => x.Title == request.Title && x.Id != toDo.Id).AnyAsync();

        businessRules.ToDoTitleDoesNotExist(isToDoTitleExist);

        toDo = mapper.Map(request, toDo);

        toDoRepository.Update(toDo);
        await unitOfWork.SaveChangesAsync();

        return ReturnModel.Success(HttpStatusCode.NoContent);
    }

    private List<ToDo> CheckCompleted(bool? completed, List<ToDo> todos)
    {
        if (completed.HasValue)
        {
            todos = todos.Where(todo => todo.Completed == completed.Value).ToList();
        }

        return todos;
    }

}
