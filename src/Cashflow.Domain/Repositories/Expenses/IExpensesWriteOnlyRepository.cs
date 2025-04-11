using Cashflow.Domain.Entities;

namespace Cashflow.Infra.Repositories.Expenses;

public interface IExpensesWriteOnlyRepository
{
    Task Add(Expense expense);
    Task<bool> Delete(long id);
}