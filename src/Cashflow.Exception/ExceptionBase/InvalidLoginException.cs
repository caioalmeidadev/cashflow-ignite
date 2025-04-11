using System.Net;

namespace Cashflow.Exception.ExceptionBase;

public class InvalidLoginException:CashflowException
{
    public InvalidLoginException() : base("Email e/ou senha inválidos")
    {
    }

    public override int StatusCode => (int)HttpStatusCode.Unauthorized;
    public override List<string> GetErrors() => [Message];

}