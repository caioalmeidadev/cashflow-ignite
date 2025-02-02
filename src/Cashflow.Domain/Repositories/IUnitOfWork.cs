namespace Cashflow.Domain.Repositories;

public interface IUnitOfWork
{
    void Commit();
    
}