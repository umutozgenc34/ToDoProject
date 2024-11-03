using AutoMapper;
using ToDoProject.Model.ToDos.Dtos.Create.Request;
using ToDoProject.Model.ToDos.Dtos.Create.Response;
using ToDoProject.Model.ToDos.Dtos.Global;
using ToDoProject.Model.ToDos.Dtos.Update;
using ToDoProject.Model.ToDos.Entity;


namespace ToDoProject.Service.ToDoS.Mapping;

public class ToDoMappingProfile : Profile
{
    public ToDoMappingProfile()
    {
        CreateMap<ToDo, ToDoDto>().ReverseMap();
        CreateMap<CreateToDoRequestDto, ToDo>().ForMember(des => des.Title,
            opt => opt.MapFrom(src => src.Title.ToLowerInvariant()));
        CreateMap<UpdateToDoRequestDto, ToDo>().ForMember(des => des.Title,
            opt => opt.MapFrom(src => src.Title.ToLowerInvariant()));
        CreateMap<ToDo, CreateToDoResponseDto>();
    }
}
