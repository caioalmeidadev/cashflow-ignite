using Cashflow.Domain.Enums;

namespace Cashflow.Domain.Entities;

public class Expense
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    
    public PaymentType PaymentType { get; set; }
    
    public long userId { get; set; }
    public User User { get; set; } = default!;
}