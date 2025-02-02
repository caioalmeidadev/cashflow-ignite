namespace Cashflow.Communication.Response;

public class ResponseErrorJson
{
    public List<string> ErrorMessage { get; set; }

    public ResponseErrorJson(string message)
    {
        ErrorMessage = [message];
    }
    
    public ResponseErrorJson(List<string> errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    
}