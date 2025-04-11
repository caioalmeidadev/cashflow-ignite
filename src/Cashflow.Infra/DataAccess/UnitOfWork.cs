using Cashflow.Domain.Repositories;

namespace Cashflow.Infra.DataAccess;

internal class UnitOfWork:IUnitOfWork
{
    private readonly CashflowDBContext _context;

    public UnitOfWork(CashflowDBContext context)
    {
        _context = context;
    }
    public async Task Commit() => await _context.SaveChangesAsync();
    
}