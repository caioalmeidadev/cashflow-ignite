using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Validators;

namespace Cashflow.Application.UseCases.User;

public partial class PasswordValidator<T> : PropertyValidator<T, string>
{
    private const string ERROR_MESSAGE_KEY = "ErrorMessage";
    
    protected override string GetDefaultMessageTemplate(string errorCode)
    {
        return $"{{{ERROR_MESSAGE_KEY}}}";
    }

    public override string Name => "PasswordValidator";

    public override bool IsValid(ValidationContext<T> context, string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            context.MessageFormatter.AppendArgument("ErrorMessage", "Senha inválida");
            return false;
        }

        if (password.Length < 8)
        {
            context.MessageFormatter.AppendArgument("ErrorMessage", "Senha inválida");
            return false;
        }


        if (!UppperCaseLetter().IsMatch(password))
        {
            context.MessageFormatter.AppendArgument("ErrorMessage", "Senha inválida");
            return false;
        }

        if (!LowwerCaseLetter().IsMatch(password))
        {
            context.MessageFormatter.AppendArgument("ErrorMessage", "Senha inválida");
            return false;
        }

        if (!EspecialSymbols().IsMatch(password))
        {
            context.MessageFormatter.AppendArgument("ErrorMessage", "Senha inválida");
            return false;
        }

        if (!NumbersOnly().IsMatch(password))
        {
            context.MessageFormatter.AppendArgument("ErrorMessage", "Senha inválida");
            return false;
        }

        return true;
    }

    [GeneratedRegex(@"[A-Z]+")]
    private static partial Regex UppperCaseLetter();
    [GeneratedRegex(@"[a-z]+")]
    private static partial Regex LowwerCaseLetter();
    [GeneratedRegex(@"[\!\?\*\.]+")]
    private static partial Regex EspecialSymbols();
    [GeneratedRegex(@"[0-9]+")]
    private static partial Regex NumbersOnly();
}


    
