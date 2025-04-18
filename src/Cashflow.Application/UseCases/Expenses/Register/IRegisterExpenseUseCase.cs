using Cashflow.Communication.Requests;
using Cashflow.Communication.Response;

namespace Cashflow.Application.UseCases.Expenses.Register;

public interface IRegisterExpenseUseCase 
{
    Task<ResponseRegisteredExpenseJson> Execute(RequestExpenseJson request); 
}