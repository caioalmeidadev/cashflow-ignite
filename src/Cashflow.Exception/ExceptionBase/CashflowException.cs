namespace Cashflow.Exception.ExceptionBase;

public abstract class CashflowException : SystemException
{
    public CashflowException(string message) : base(message) { }
    
    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();

}