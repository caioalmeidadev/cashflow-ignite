using Cashflow.Communication.Response;
using Cashflow.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cashflow.API.Filters;

public class ExceptionFilter: IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is CashflowException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnknowError(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        var cashflowException = (CashflowException)context.Exception;
        var errorResponse = new ResponseErrorJson(cashflowException.GetErrors());
        context.HttpContext.Response.StatusCode = cashflowException.StatusCode;
        
        context.Result = new ObjectResult(errorResponse);
    }
    
    private void ThrowUnknowError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson("Unknow error");
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);


    }
}