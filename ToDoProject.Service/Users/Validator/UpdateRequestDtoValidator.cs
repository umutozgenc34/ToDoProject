using FluentValidation;

using ToDoProject.Model.Users.Dtos.Request;

namespace ToDoProject.Service.Users.Validator;

public class UpdateRequestDtoValidator : AbstractValidator<UpdateRequestDto>
{
    public UpdateRequestDtoValidator()
    {
        RuleFor(x => x.Username)
         .NotEmpty().WithMessage("Kullanıcı adı boş olamaz.")
         .MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakter olmalıdır.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Ad alanı boş olamaz.")
            .MinimumLength(2).WithMessage("Ad en az 2 karakter olmalıdır.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Soyad alanı boş olamaz.")
            .MinimumLength(2).WithMessage("Soyad en az 2 karakter olmalıdır.");
    }
}
