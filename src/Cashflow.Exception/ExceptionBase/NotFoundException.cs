using System.Net;

namespace Cashflow.Exception.ExceptionBase;

public class NotFoundException:CashflowException
{
    

    public NotFoundException(string message):base(message){}
    
    public override int StatusCode => (int)HttpStatusCode.NotFound;
    
    public override List<string> GetErrors() => [Message];
}