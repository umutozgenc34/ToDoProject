

using FluentValidation;
using ToDoProject.Model.ToDos.Dtos.Create.Request;

namespace ToDoProject.Service.ToDoS.Validator;

public class CreateToDoRequestDtoValidator : AbstractValidator<CreateToDoRequestDto>
{
    public CreateToDoRequestDtoValidator()
    {
        RuleFor(x => x.Title)
           .NotEmpty().WithMessage("ToDo ismi gereklidir")
           .Length(3, 25).WithMessage("Todo ismi 3 ile 25 karakter arasında olmalıdır");


        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("ToDo açıklaması gereklidir")
            .Length(1, 512);


        RuleFor(x => x.Priority)
            .NotEmpty().WithMessage("Öncelik girilmesi zorunludur '1 En yüksek öncelik, 3 En düşük öncelik'");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("categoryId 0 dan büyük olmalıdır");
    }
}
