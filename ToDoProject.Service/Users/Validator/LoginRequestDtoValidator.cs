

using FluentValidation;
using ToDoProject.Model.Users.Dtos.Request;

namespace ToDoProject.Service.Users.Validator;

public class LoginRequestDtoValidator : AbstractValidator<LoginRequestDto>
{
    public LoginRequestDtoValidator()
    {
        RuleFor(x => x.Email)
          .NotEmpty().WithMessage("E-posta adresi boş olamaz.")
          .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifre boş olamaz.")
            .MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır.");
    }
}
