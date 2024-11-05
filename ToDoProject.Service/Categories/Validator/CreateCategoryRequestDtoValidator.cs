using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoProject.Model.Categories.Dtos.Create;

namespace ToDoProject.Service.Categories.Validator;

public class CreateCategoryRequestDtoValidator : AbstractValidator<CreateCategoryRequestDto>
{
    public CreateCategoryRequestDtoValidator()
    {
        RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Category ismi gereklidir")
           .Length(3, 25).WithMessage("Category ismi 3 ile 25 karakter arasında olmalıdır");
    }
}
