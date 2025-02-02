using Cashflow.Application.UseCases.Expenses.Register;
using Cashflow.Communication.Requests;
using Cashflow.Communication.Response;
using Cashflow.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;

namespace Cashflow.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public IActionResult Register(
        [FromServices] IRegisterExpenseUseCase useCase,
        [FromBody]ResquestRegisterExpenseJson request)
    {
        var response = useCase.Execute(request);
        return Created(string.Empty, response);
    }
}