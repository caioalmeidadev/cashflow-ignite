using Cashflow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cashflow.Infra.DataAccess;

internal class CashflowDBContext:DbContext
{
    public CashflowDBContext(DbContextOptions options) : base(options){}
    public DbSet<Expense> Expenses { get; set; }
   
}