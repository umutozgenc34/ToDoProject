

using FluentValidation;
using ToDoProject.Model.Categories.Dtos.Update;

namespace ToDoProject.Service.Categories.Validator;

public class UpdateCategoryRequestDtoValidator : AbstractValidator<UpdateCategoryRequestDto>
{
    public UpdateCategoryRequestDtoValidator()
    {
        RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Category ismi gereklidir")
           .Length(3, 25).WithMessage("Category ismi 3 ile 25 karakter arasında olmalıdır");
    }
}
