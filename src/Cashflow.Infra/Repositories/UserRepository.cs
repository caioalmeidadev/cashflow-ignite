using Cashflow.Domain.Entities;
using Cashflow.Domain.Repositories.User;
using Cashflow.Infra.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Cashflow.Infra.Repositories;

internal class UserRepository:IUserReadOnlyRepository,IUserWriteOnlyRepository
{
    private readonly CashflowDBContext _dbContext;
    
    public UserRepository(CashflowDBContext dbContext) => _dbContext = dbContext;
    
    public async Task<bool> ExistsActiveUserWithEmail(string email)
    {
        return await _dbContext.Users.AnyAsync(user => user.Email.Equals(email));
    }

    public async Task<User?> GetByEmail(string email)
    {
        //lembrar de usar AsNoTracking, pois não vai ter alteração no resultado da query
       return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Email.Equals(email));
    }

    public async Task Add(User user)
    {
        await _dbContext.Users.AddAsync(user);
    }
}