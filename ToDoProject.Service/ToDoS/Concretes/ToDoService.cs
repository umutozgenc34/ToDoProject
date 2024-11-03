

using AutoMapper;
using Core.Entities.ReturnModels;
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

namespace ToDoProject.Service.ToDoS.Concretes;

public class ToDoService(IToDoRepository toDoRepository,IUnitOfWork unitOfWork,IMapper mapper) : IToDoService
{
    public async Task<ReturnModel<CreateToDoResponseDto>> CreateAsync(CreateToDoRequestDto request)
    {
        var anyTodo = await toDoRepository.Where(x=> x.Title == request.Title).AnyAsync();
        if (anyTodo)
        {
            return ReturnModel<CreateToDoResponseDto>.Fail("ToDo ismi veritabanında bulunmaktadır");
        }

        var toDo = mapper.Map<ToDo>(request);
        await toDoRepository.AddAsync(toDo);
        await unitOfWork.SaveChangesAsync();

        var toDoResponse = mapper.Map<CreateToDoResponseDto>(toDo);

        return ReturnModel<CreateToDoResponseDto>.Success(toDoResponse, HttpStatusCode.Created);
           
    }

    public async Task<ReturnModel> DeleteAsync(Guid id)
    {
        var toDo = await toDoRepository.GetByIdAsync(id);
        if (toDo is null)
        {
            return ReturnModel.Fail("Silinecek task bulunamadı.", HttpStatusCode.NotFound);
        }
        
        toDoRepository.Delete(toDo);
        await unitOfWork.SaveChangesAsync();

        return ReturnModel.Success(HttpStatusCode.NoContent);
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
        if (toDo is null)
        {
            return ReturnModel<ToDoDto?>.Fail("Kullanıcı Bulunamadı",HttpStatusCode.NotFound);
        }

        var toDoAsDto = mapper.Map<ToDoDto>(toDo);
        
        return ReturnModel<ToDoDto?>.Success(toDoAsDto);
    }

    public async Task<ReturnModel> UpdateAsync(Guid id, UpdateToDoRequestDto request)
    {
        var toDo = await toDoRepository.GetByIdAsync(id);
        if(toDo is null)
        {
            return ReturnModel.Fail("ToDo bulunamadı", HttpStatusCode.NotFound);
        }

        var isToDoTitleExist = await toDoRepository.Where(x => x.Title == request.Title && x.Id != toDo.Id).AnyAsync();

        if (isToDoTitleExist)
        {
            return ReturnModel.Fail("ToDo ismi veritabanında bulunmaktadır");
        }

        toDo = mapper.Map(request, toDo);

        toDoRepository.Update(toDo);
        await unitOfWork.SaveChangesAsync();

        return ReturnModel.Success(HttpStatusCode.NoContent);
    }
}
