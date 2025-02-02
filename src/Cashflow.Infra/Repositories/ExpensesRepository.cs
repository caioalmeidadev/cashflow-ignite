using Cashflow.Domain.Entities;
using Cashflow.Domain.Repositories;
using Cashflow.Infra.DataAccess;

namespace Cashflow.Infra.Repositories;

internal class ExpensesRepository:IExpensesRepository
{
    private readonly CashflowDBContext _DbContext;

    public ExpensesRepository(CashflowDBContext dbContext)
    {
        _DbContext = dbContext;
    }
    public void Add(Expense expense)
    {
        _DbContext.Expenses.Add(expense);
    }
}