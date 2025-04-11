namespace Cashflow.Domain.Repositories;

public interface IUnitOfWork
{
    Task Commit();
    
}