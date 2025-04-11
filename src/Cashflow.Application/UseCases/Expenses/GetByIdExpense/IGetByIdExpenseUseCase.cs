using Cashflow.Communication.Response;

namespace Cashflow.Application.UseCases.Expenses.GetByIdExpense;

public interface IGetByIdExpenseUseCase
{
    Task<ResponseExpenseShortJson> Execute(long id);
}