

using Core.Entities.ReturnModels;
using ToDoProject.Model.ToDos.Dtos.Create.Request;
using ToDoProject.Model.ToDos.Dtos.Create.Response;
using ToDoProject.Model.ToDos.Dtos.Global;
using ToDoProject.Model.ToDos.Dtos.Update;

namespace ToDoProject.Service.ToDoS.Abstracts;

public interface IToDoService
{
    Task<ReturnModel<List<ToDoDto>>> GetAllListAsync();
    Task<ReturnModel<ToDoDto?>> GetByIdAsync(Guid id);
    Task<ReturnModel<CreateToDoResponseDto>> CreateAsync(CreateToDoRequestDto request);
    Task<ReturnModel> UpdateAsync(Guid id, UpdateToDoRequestDto request);
    Task<ReturnModel> DeleteAsync(Guid id);

}
