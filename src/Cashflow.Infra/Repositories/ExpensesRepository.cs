using Cashflow.Domain.Entities;
using Cashflow.Domain.Repositories;
using Cashflow.Infra.DataAccess;
using Cashflow.Infra.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace Cashflow.Infra.Repositories;

internal class ExpensesRepository:IExpensesWriteOnlyRepository,IExpensesReadOnlyRepository,IExpensesUpdateOnlyRepository
{
    private readonly CashflowDBContext _DbContext;

    public ExpensesRepository(CashflowDBContext dbContext)
    {
        _DbContext = dbContext;
    }
    public async Task Add(Expense expense)
    {
        await _DbContext.Expenses.AddAsync(expense);
    }

    public async Task<List<Expense>> GetAll()
    {
      return await _DbContext.Expenses.AsNoTracking().ToListAsync();
    }

    async Task<Expense?>  IExpensesReadOnlyRepository.GetById(long id)
    {
        return await _DbContext.Expenses.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }
    
    async Task<Expense?>  IExpensesUpdateOnlyRepository.GetById(long id)
    {
        return await _DbContext.Expenses.FirstOrDefaultAsync(x => x.Id == id);
    }

    public void Update(Expense expense)
    {
        _DbContext.Expenses.Update(expense);
    }

    public async Task<bool> Delete(long id)
    {
        var result = await _DbContext.Expenses.FirstOrDefaultAsync(expense => expense.Id == id);
        if(result is null)
        {
            return false;
        }
 
        _DbContext.Expenses.Remove(result);
 
        return true;
    }
}