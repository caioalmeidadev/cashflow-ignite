using Cashflow.Communication.Requests;
using FluentValidation;

namespace Cashflow.Application.UseCases.User.Register;

public class RegisterUserValidator:AbstractValidator<RequestRegisterUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage("O nome de usuário não pode ser vazio");
        RuleFor(user => user.Email).NotEmpty().WithMessage("O email não pode ser vazio").EmailAddress().WithMessage("O email é inválido");
        RuleFor(user => user.Password).SetValidator(new PasswordValidator<RequestRegisterUserJson>());
    }
}