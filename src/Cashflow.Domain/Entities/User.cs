using Cashflow.Domain.Enums;

namespace Cashflow.Domain.Entities;

public class User
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Guid Identifier { get; set; } = Guid.NewGuid();
    
    public string Role { get; set; } = Roles.MEMBER;
}