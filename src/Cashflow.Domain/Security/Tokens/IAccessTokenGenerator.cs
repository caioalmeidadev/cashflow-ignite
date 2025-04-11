using Cashflow.Domain.Entities;

namespace Cashflow.Domain.Security.Tokens;

public interface IAccessTokenGenerator
{
    string Generate(User user);
}