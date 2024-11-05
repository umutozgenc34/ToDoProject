using FluentValidation;

using ToDoProject.Model.Users.Dtos.Request;

namespace ToDoProject.Service.Users.Validator;

public class ChangePasswordRequestDtoValidator : AbstractValidator<ChangePasswordRequestDto>
{
    public ChangePasswordRequestDtoValidator()
    {
        RuleFor(x => x.OldPassword)
          .NotEmpty().WithMessage("Eski şifre boş olamaz.")
          .MinimumLength(6).WithMessage("Eski şifre en az 6 karakter olmalıdır.");

        RuleFor(x => x.NewPassword)
            .NotEmpty().WithMessage("Yeni şifre boş olamaz.")
            .MinimumLength(6).WithMessage("Yeni şifre en az 6 karakter olmalıdır.")
            .NotEqual(x => x.OldPassword).WithMessage("Yeni şifre eski şifreyle aynı olamaz.");
    }
}
