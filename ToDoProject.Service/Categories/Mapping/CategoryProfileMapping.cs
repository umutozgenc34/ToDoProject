

using AutoMapper;
using ToDoProject.Model.Categories.Dtos.Create;
using ToDoProject.Model.Categories.Dtos.Global;
using ToDoProject.Model.Categories.Dtos.Update;
using ToDoProject.Model.Categories.Entity;

namespace ToDoProject.Service.Categories.Mapping;

public class CategoryProfileMapping : Profile
{
    public CategoryProfileMapping()
    {
        CreateMap<CategoryDto, Category>().ReverseMap();
        CreateMap<Category, CategoryWithTodosDto>().ReverseMap();
        CreateMap<CreateCategoryRequestDto, Category>().ForMember(des => des.Name,
            opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));

        CreateMap<UpdateCategoryRequestDto, Category>().ForMember(des => des.Name,
            opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));

    }
}
