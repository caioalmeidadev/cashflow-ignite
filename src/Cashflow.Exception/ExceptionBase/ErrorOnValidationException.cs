using System.Net;

namespace Cashflow.Exception.ExceptionBase;

public class ErrorOnValidationException: CashflowException
{
    private List<string> _errors { get; set; }

    public override int StatusCode => (int)HttpStatusCode.BadRequest;
    public override List<string> GetErrors() => _errors;

    public ErrorOnValidationException(List<string> errorMessages):base(String.Empty)
    {
        _errors = errorMessages;
    }
}