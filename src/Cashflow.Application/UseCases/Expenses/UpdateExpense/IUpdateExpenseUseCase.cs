using Cashflow.Communication.Requests;

namespace Cashflow.Application.UseCases.Expenses.UpdateExpense;

public interface IUpdateExpenseUseCase
{
    Task Execute(long id, RequestExpenseJson request);
}